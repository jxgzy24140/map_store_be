using map_project.Models;

namespace map_project.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetAsync(int id);
        Task CreateAsync(Event input);
        Task DeleteAsync(int id);
    }
}
