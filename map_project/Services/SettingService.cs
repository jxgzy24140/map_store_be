using map_project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace map_project.Services
{
    public class SettingService : ISettingService
    {
        private readonly IMongoCollection<Setting> _settingCollection;

        public SettingService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(
             mongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDBSettings.Value.DatabaseName);

            _settingCollection = mongoDatabase.GetCollection<Setting>(
                mongoDBSettings.Value.SettingsCollectionName);
        }
        public async Task CreateAsync(Setting setting)
        {
            await _settingCollection.InsertOneAsync(setting);
        }

        public async Task DeleteAsync(int id)
        {
            await _settingCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            var result = await _settingCollection.Find(_ => true).ToListAsync();
            return result;
        }

        public async Task<Setting> GetAsync(int id)
        {
            var setting = await _settingCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (setting != null)
            {
                return setting;

            }
            return null;
        }

        public async Task<Setting?> UpdateAsync(int id, Setting input)
        {
            if (id != input.Id) return null;
            await _settingCollection.ReplaceOneAsync(x => x.Id == id, input);
            var updatedSetting = await GetAsync(id);
            return updatedSetting;
        }
    }
}
