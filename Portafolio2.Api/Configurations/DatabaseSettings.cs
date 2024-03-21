namespace Portafolio2.Api.Configurations;

public class DatabaseSettings
{
    public string ConnectionString {get;set;} = string.Empty;
    public string DatabaseName {get;set;} = string.Empty;
    public string CollectionInfoPersonal {get;set;} = string.Empty; //ESTO ES PROVEEDOR
    public string CollectionProyectos { get;set;} = string.Empty;
}