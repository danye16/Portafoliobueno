using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Portafolio2.Api.Configurations;
using Portafolio2.Api.Models;

namespace Portafolio2.Api.Services
{
    public class InfoPersonalServices
    {
     private readonly IMongoCollection<InfoPersonal> _infoPersonalCollection;

     public InfoPersonalServices(
        IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB=
            mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _infoPersonalCollection=
            mongoDB.GetCollection<InfoPersonal>
            (databaseSettings.Value.CollectionInfoPersonal);
        }
      public async Task<List<InfoPersonal>> GetAsync() =>
 await _infoPersonalCollection.Find(_ => true).ToListAsync();

        public async Task InsertInfo(InfoPersonal infopersonal)
{
    await _infoPersonalCollection.InsertOneAsync(infopersonal);
}

public async Task UpdateInfo(InfoPersonal infopersonal)
{
    var filter = Builders<InfoPersonal>.Filter.Eq(s => s.Id, infopersonal.Id);
    await _infoPersonalCollection.ReplaceOneAsync(filter, infopersonal);
}

public async Task DeleteInfo(string id)
{
    var filter = Builders<InfoPersonal>.Filter.Eq(s => s.Id, id);
    await _infoPersonalCollection.DeleteOneAsync(filter);
}
    }
}