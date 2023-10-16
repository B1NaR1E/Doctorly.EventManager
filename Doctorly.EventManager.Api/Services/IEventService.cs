using Doctorly.EventManager.Api.DTOs.Event;

namespace Doctorly.EventManager.Api.Services;

public interface IEventService
{
    Task<CreateEventResponse> CreateEventAsync(CreateEventRequest request);
    Task<CancelEventResponse> CancelEventAsync(CancelEventRequest request);
    Task<SetAttendanceResponse> SetAttendanceAsync(SetAttendanceRequest request);
    Task<UpdateEventResponse> UpdateEventAsync(UpdateEventRequest request);
    Task<GetEventsResponse> GetEventsAsyns(DateTime? startTime, DateTime? endTime);
}
