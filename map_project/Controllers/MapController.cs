using map_project.Models;
using map_project.Services;
using Microsoft.AspNetCore.Mvc;
namespace map_project.Controllers
{
    [ApiController]
    [Route("/api/v1/map")]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mongoDBService;

        public MapController(IMapService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(string? clientName, DateTime? fromDate) {
            var maps = await _mongoDBService.GetAllAsync(clientName, fromDate);
            return Ok(maps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var map = await _mongoDBService.GetAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            return Ok(map);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Map map) {
            map.Id = Guid.NewGuid();
            var newMap = await _mongoDBService.CreateAsync(map);
            return Ok(newMap);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(Guid id) {
            _mongoDBService.DeleteAsync(id);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(Guid id, Map map)
        {
            if (id != map.Id) return NotFound();
            var result = await _mongoDBService.UpdateAsync(id, map);
            if (result == null) return NotFound();
            return Ok(result);

        }

    }
}
