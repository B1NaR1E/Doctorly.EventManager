using AutoMapper;
using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Api.Validators.Event;
using Doctorly.EventManager.Domain.Events;
using Doctorly.EventManager.Infrastructure.Data.Repositries;

namespace Doctorly.EventManager.Api.Services;

public class EventService : IEventService
{
    private readonly EventRepository _repository;
    private readonly IMapper _mapper;

    public EventService(EventRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateEventResponse> CreateEventAsync(CreateEventRequest request)
    {
        var response = new CreateEventResponse();
        var validator = new UpsertEventRequestValidator();

        try
        {
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }

            var @event = new Event();
            @event.SetEventInfo(request.Title, request.Description, request.StartTime, request.EndTime);

            foreach (var attendeeId in request.AttendeeIds)
            {
                @event.AddAttendee(attendeeId);
            }

            var result = await _repository.AddAsync(@event);
            await _repository.SaveChangesAsync();

            response.Successfull = true;
            
            response.Response = _mapper.Map<EventDto>(result);
            response.Message = "Event successfully created.";
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = "An unexpected error has occurred while trying to create an event.";
        }

        return response;
    }

    public async Task<UpdateEventResponse> UpdateEventAsync(UpdateEventRequest request)
    {
        var response = new UpdateEventResponse();
        var validator = new UpsertEventRequestValidator();

        try
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }

            var @event = await _repository.GetEventWithAttendeesAsync(request.Id);

            if (@event is null)
            {
                response.Successfull = false;
                response.Message = $"Error updating event. Could not find event for event id: {request.Id}.";
            }

            @event!.SetEventInfo(request.Title, request.Description, request.StartTime, request.EndTime);

            //TODO: Need to add logic to update attendees as well.

            var result = await _repository.UpdateAsync(@event);
            await _repository.SaveChangesAsync();

            response.Successfull = true;
            response.Message = "Event successfully update.";
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = "An unexpected error has occurred while trying to update an event.";
        }

        return response;
    }

    public async Task<CancelEventResponse> CancelEventAsync(CancelEventRequest request)
    {
        var response = new CancelEventResponse();

        try
        {
            var @event = await _repository.GetAsync(e => e.Id == request.EventId);

            if (@event is null)
            {
                response.Successfull = false;
                response.Message = $"Error canceling event. Could not find event for event id: {request.EventId}.";
            }

            @event!.Cancel();

            await _repository.UpdateAsync(@event);

            await _repository.SaveChangesAsync();

            response.Successfull = true;
            response.Message = "Event successfully cancelled.";
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = "An unexpected error has occurred while trying to cancel an event.";
        }

        return response;
    }

    public async Task<SetAttendanceResponse> SetAttendanceAsync(SetAttendanceRequest request)
    {
        var response = new SetAttendanceResponse();

        try
        {
            var @event = await _repository.GetEventWithAttendeesAsync(request.EventId);

            if(@event is null)
            {
                response.Successfull = false;
                response.Message = $"Error setting attendance for event.Could not find event for event id: {request.EventId}.";
            }

            @event!.SetAttending(request.AttendeeId, request.Attending);

            await _repository.UpdateAsync(@event);

            await _repository.SaveChangesAsync();

            response.Successfull = true;
            response.Message = $"Attendance for attendeeId: {request.AttendeeId} has been set successfully.";
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = $"An unexpected error has occurred while trying to set the attandance for attendee: {request.AttendeeId} for event: {request.EventId}.";
        }

        return response;
    }
}
