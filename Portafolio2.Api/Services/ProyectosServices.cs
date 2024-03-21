using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Portafolio2.Api.Configurations;
using Portafolio2.Api.Models;

namespace Portafolio2.Api.Services
{
    public class ProyectosServices
    {
     private readonly IMongoCollection<Proyectos> _proyectosCollection;

     public ProyectosServices(
        IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB=
            mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _proyectosCollection=
            mongoDB.GetCollection<Proyectos>
            (databaseSettings.Value.CollectionProyectos);
        }
      public async Task<List<Proyectos>> GetAsync() =>
 await _proyectosCollection.Find(_ => true).ToListAsync();

        public async Task InsertProyecto(Proyectos proyectos)
{
    await _proyectosCollection.InsertOneAsync(proyectos);
}

public async Task UpdateProyecto(Proyectos proyectos)
{
    var filter = Builders<Proyectos>.Filter.Eq(s => s.Id, proyectos.Id);
    await _proyectosCollection.ReplaceOneAsync(filter, proyectos);
}

public async Task DeleteProyecto(string id)
{
    var filter = Builders<Proyectos>.Filter.Eq(s => s.Id, id);
    await _proyectosCollection.DeleteOneAsync(filter);
}
    //Buscar por ID
 public async Task<Proyectos> GetProyectoById(string id)
 {
     return await _proyectosCollection.FindAsync(new BsonDocument 
     {{"_id", new ObjectId(id)}}).Result.FirstAsync();
 }
   
    }
}