using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Portafolio2.Api.Models;

public class Proyectos
{
      [BsonId] //obtener el id autogenerado por MongoDB
  [BsonRepresentation(BsonType.ObjectId)]

  public string Id { get; set; } = string.Empty;
  [BsonElement("Nombre")]
  public string Nombre { get; set; } = string.Empty;
   [BsonElement("Imagen")]

  public string Imagen { get; set; } = string.Empty;
    [BsonElement("Descripcion")]

  public string Descripcion { get; set; } = string.Empty;
   [BsonElement("Link")]

  public string Link { get; set; } = string.Empty;
    [BsonElement("stack")]

    public string stack { get; set; } = string.Empty;
}