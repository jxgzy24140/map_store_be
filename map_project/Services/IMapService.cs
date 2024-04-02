using map_project.Models;
using MongoDB.Bson;

namespace map_project.Services
{
    public interface IMapService
    {
        Task<List<Map>> GetAllAsync(string? clientName, DateTime? fromDate);
        Task<Map?> GetAsync(Guid id);
        Task<Map> CreateAsync(Map map);
        Task DeleteAsync(Guid id);
        Task<Map?> UpdateAsync(Guid id, Map map);
    }
}
