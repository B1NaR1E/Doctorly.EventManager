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

        [HttpPost("create")]
        public async Task<IActionResult> CreateEventAsync(CreateEventRequest request)
        {
            var reponse = await _eventService.CreateEventAsync(request);
            return Ok(reponse);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelEventAsync(CancelEventRequest request)
        {
            var reponse = await _eventService.CancelEventAsync(request);
            return Ok(reponse);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateEventAsync(UpdateEventRequest request)
        {
            var reponse = await _eventService.UpdateEventAsync(request);
            return Ok(reponse);
        }

        [HttpPost("set-attendance")]
        public async Task<IActionResult> SetAttendanceAsync(SetAttendanceRequest request)
        {
            var reponse = await _eventService.SetAttendanceAsync(request);
            return Ok(reponse);
        }
    }
}
