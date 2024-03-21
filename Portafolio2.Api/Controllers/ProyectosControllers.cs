using Portafolio2.Api.Models;
using Portafolio2.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Portafolio2.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProyectosController : ControllerBase
{
    private readonly ILogger<ProyectosController> _logger;
    private readonly ProyectosServices _proyectosServices;
    public ProyectosController(
        ILogger<ProyectosController> logger,
        ProyectosServices proyectosServices)
    {
        _logger = logger;
        _proyectosServices = proyectosServices;
    }
    //MOSTRAR
    [HttpGet("Listar")]
    public async Task<IActionResult> GetUsuario()
    {
        try
        {
            var proyectos = await _proyectosServices.GetAsync();
            return Ok(proyectos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener los usuarios");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //INSERTAR
    [HttpPost("Crear")]
    public async Task<IActionResult> CreateDriver([FromBody] Proyectos proyectos)
    {
        try
        {
            if (proyectos == null)
                return BadRequest("El correo no puede ser null");
            if (proyectos.Link == string.Empty)
                return BadRequest("El link del proyecto no puede estar vacío");

            await _proyectosServices.InsertProyecto(proyectos);
            return Created("Created", true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear el proyecto");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //ELIMINAR
    [HttpDelete("Borrar/{Id}")]
    public async Task<IActionResult> DeleteUsuario(string Id)
    {
        try
        {
            await _proyectosServices.DeleteProyecto(Id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al borrar el proyecto");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

    //EDITAR
    [HttpPut("Editar")]
    public async Task<IActionResult> UpdateProyecto([FromBody] Proyectos proyectos, string Id)
    {
        try
        {
            if (proyectos == null)
                return BadRequest("El proyecto no puede ser null");
            if (proyectos.Nombre == string.Empty)
                return BadRequest("El nombre del proyecto no puede estar vacío");

            proyectos.Id = Id;
            await _proyectosServices.UpdateProyecto(proyectos);
            return Created("Created", true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar el proyecto");
            return StatusCode(500, "Error interno del servidor. Por favor, inténtalo de nuevo más tarde.");
        }
    }

   [HttpGet("Buscarby/{id}")]
public async Task <IActionResult> GetProyectoById(string id)
{
    return Ok(await _proyectosServices.GetProyectoById(id));
}
    //BUSCAR POR ID
    
}