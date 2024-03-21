using Portafolio2.Api.Models;
using Portafolio2.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Portafolio2.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly InfoPersonalServices _infopersonalServices;
    public UsuarioController(
        ILogger<UsuarioController> logger,
        InfoPersonalServices infopersonalServices)
    {
        _logger = logger;
        _infopersonalServices = infopersonalServices;
    }
    //MOSTRAR
    [HttpGet("Listar")]
    public async Task<IActionResult> GetUsuario()
    {
        try
        {
            var usuario = await _infopersonalServices.GetAsync();
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener los usuarios");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //INSERTAR
    [HttpPost("Crear")]
    public async Task<IActionResult> CreateDriver([FromBody] InfoPersonal usuario)
    {
        try
        {
            if (usuario == null)
                return BadRequest("El correo no puede ser null");
            if (usuario.Correo == string.Empty)
                return BadRequest("El correo del usuario no puede estar vacío");

            await _infopersonalServices.InsertInfo(usuario);
            return Created("Created", true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear el usuario");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //ELIMINAR
    [HttpDelete("Borrar/{Id}")]
    public async Task<IActionResult> DeleteUsuario(string Id)
    {
        try
        {
            await _infopersonalServices.DeleteInfo(Id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al borrar el usuario");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //EDITAR
    [HttpPut("Editar")]
    public async Task<IActionResult> UpdateUser([FromBody] InfoPersonal usuario, string Id)
    {
        try
        {
            if (usuario == null)
                return BadRequest("El usuario no puede ser null");
            if (usuario.Correo == string.Empty)
                return BadRequest("El nombre del usuario no puede estar vacío");

            usuario.Id = Id;
            await _infopersonalServices.UpdateInfo(usuario);
            return Created("Created", true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar el usuario");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //BUSCAR POR ID
    
}