using Doctorly.EventManager.Api.DTOs.Attendee;

namespace Doctorly.EventManager.Api.Services;

public interface IAttendeeService
{
    Task<CreateAttendeeResponse> CreateAttendeeAsync(CreateAttendeeRequest request);
}
