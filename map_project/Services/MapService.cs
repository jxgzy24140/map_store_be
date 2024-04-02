using map_project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace map_project.Services
{
    public class MapService : IMapService
    {

        private readonly IMongoCollection<Map> _mapCollection;

        public MapService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(
             mongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDBSettings.Value.DatabaseName);

            _mapCollection = mongoDatabase.GetCollection<Map>(
                mongoDBSettings.Value.MapsCollectionName);
        }

        public async Task<List<Map>> GetAllAsync(string? clientName, DateTime? fromDate)
        {
            var filterBuilder = Builders<Map>.Filter;
            var filter = filterBuilder.Empty;

            // Add filter for ClientName if provided
            if (!string.IsNullOrEmpty(clientName))
            {
                filter &= filterBuilder.Regex("clientName", new BsonRegularExpression(clientName, "i"));
            }

            if (fromDate.HasValue)
            {
                filter &= filterBuilder.Gte("creationTime", fromDate.Value);
            }

            var maps = await _mapCollection.Find(filter).ToListAsync();
            return maps;
        }
        public async Task<Map?> GetAsync(Guid id)
        {
            var map = await _mapCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (map != null)
            {
                return map;

            }
            return null;
        }
        public async Task<Map> CreateAsync(Map map) {
            await _mapCollection.InsertOneAsync(map);
            var result = await GetAsync(map.Id);
            return result;
        }
        public async Task DeleteAsync(Guid id) {
            await _mapCollection.DeleteOneAsync(x => x.Id == id);
        }
        public async Task<Map?> UpdateAsync(Guid id, Map map)
        {
            if (id != map.Id) return null;
            await _mapCollection.ReplaceOneAsync(x => x.Id == id, map);
            var updatedMap = await GetAsync(id);
            return updatedMap;
        }
    }
}
