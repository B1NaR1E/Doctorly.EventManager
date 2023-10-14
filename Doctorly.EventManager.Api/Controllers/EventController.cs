using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctorly.EventManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(CreateEventRequest request)
        {
            var reponse = await _eventService.CreateEventAsync(request);
            return Ok(reponse);
        }
    }
}
