using Amazon.Runtime.Internal.Settings;
using map_project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace map_project.Services
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;

        public EventService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(
             mongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDBSettings.Value.DatabaseName);

            _eventCollection = mongoDatabase.GetCollection<Event>(
                mongoDBSettings.Value.EventsCollectionName);
        }
       
        public async Task CreateAsync(Event input)
        {
            await _eventCollection.InsertOneAsync(input);
        }

        public async Task DeleteAsync(int id)
        {
            await _eventCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<Event>> GetAllAsync()
        {
            var result = await _eventCollection.Find(_ => true).ToListAsync();
            return result;
        }

        public async Task<Event?> GetAsync(int id)
        {
            var result = await _eventCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;

            }
            return null;
        }
    }
}
