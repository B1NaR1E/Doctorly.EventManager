using Doctorly.EventManager.Api.DTOs.Attendee;
using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctorly.EventManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;

        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAttendeeAsync(CreateAttendeeRequest request)
        {
            var response = await _attendeeService.CreateAttendeeAsync(request);
            return Ok(response);
        }
    }
}
