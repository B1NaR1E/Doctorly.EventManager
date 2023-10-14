using Doctorly.EventManager.Api.DTOs.Event;

namespace Doctorly.EventManager.Api.Services;

public interface IEventService
{
    Task<CreateEventResponse> CreateEventAsync(CreateEventRequest request);
}
