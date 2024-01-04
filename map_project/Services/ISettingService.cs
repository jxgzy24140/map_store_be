using map_project.Models;

namespace map_project.Services
{
    public interface ISettingService
    {
        Task CreateAsync(Setting setting);
        Task<List<Setting>> GetAllAsync();
        Task<Setting> GetAsync(int id);
        Task<Setting?> UpdateAsync(int id, Setting input);
        Task DeleteAsync(int id);
    }
}
