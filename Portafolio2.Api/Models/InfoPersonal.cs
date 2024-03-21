using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Portafolio2.Api.Models;

public class InfoPersonal
{
      [BsonId] //obtener el id autogenerado por MongoDB
  [BsonRepresentation(BsonType.ObjectId)]

  public string Id { get; set; } = string.Empty;
  [BsonElement("Correo")]
  public string Correo { get; set; } = string.Empty;
   [BsonElement("Telefono")]

  public string Telefono { get; set; } = string.Empty;
    [BsonElement("Edad")]

  public string Edad { get; set; } = string.Empty;
   [BsonElement("Lenguajes")]

  public string Lenguajes { get; set; } = string.Empty;
   [BsonElement("Tecnologias")]

  public string Tecnologias { get; set; } = string.Empty;
  
}