using map_project.Models;
using map_project.Services;
using Microsoft.AspNetCore.Mvc;
namespace map_project.Controllers
{
    [ApiController]
    [Route("/api/v1/event")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            var maps = await _eventService.GetAllAsync();
            return Ok(maps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var map = _eventService.GetAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            return Ok(map);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Event input) {
            await _eventService.CreateAsync(input);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id) {
            _eventService.DeleteAsync(id);
        }
    }
}
