using map_project.Models;
using map_project.Services;
using Microsoft.AspNetCore.Mvc;
namespace map_project.Controllers
{
    [ApiController]
    [Route("/api/v1/setting")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            var maps = await _settingService.GetAllAsync();
            return Ok(maps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var map = await _settingService.GetAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            return Ok(map);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Setting map) {
            await _settingService.CreateAsync(map);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id) {
            _settingService.DeleteAsync(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Setting input)
        {
            if (id != input.Id) return NotFound();
            var result = await _settingService.UpdateAsync(id, input);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
