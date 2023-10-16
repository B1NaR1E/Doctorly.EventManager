using AutoMapper;
using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Api.Validators.Event;
using Doctorly.EventManager.Domain.Events;
using Doctorly.EventManager.Infrastructure;
using Doctorly.EventManager.Infrastructure.Data.Repositries;

namespace Doctorly.EventManager.Api.Services;

public class EventService : IEventService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EventService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
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

            foreach (var attendee in request.Attendees)
            {
                @event.AddAttendee(attendee.FirstName, attendee.LastName, attendee.EmailAddress);
            }

            var repo = _unitOfWork.Repository<EventRepository>();

            var result = await repo.AddAsync(@event);
            await _unitOfWork.SaveChangesAsync();

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

            var repo = _unitOfWork.Repository<EventRepository>();

            var @event = await repo.GetEventWithAttendeesAsync(request.Id);

            if (@event is null)
            {
                response.Successfull = false;
                response.Message = $"Error updating event. Could not find event for event id: {request.Id}.";
            }

            @event!.SetEventInfo(request.Title, request.Description, request.StartTime, request.EndTime);

            foreach (var attendee in request.Attendees)
            {
                var attToUpdate = @event.Attendees.FirstOrDefault(a => a.EmailAddress == attendee.EmailAddress);
                @event.Attendees.Remove(attToUpdate!);
                @event.AddAttendee(attendee.FirstName, attendee.LastName, attendee.EmailAddress);
            }

            var result = await repo.UpdateAsync(@event);
            await _unitOfWork.SaveChangesAsync();

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
            var repo = _unitOfWork.Repository<EventRepository>();

            var @event = await repo!.GetEventWithAttendeesAsync(request.EventId);

            if (@event is null)
            {
                response.Successfull = false;
                response.Message = $"Error canceling event. Could not find event for event id: {request.EventId}.";
            }

            @event!.Cancel();

            await repo.UpdateAsync(@event);

            await _unitOfWork.SaveChangesAsync();

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
            var repo = _unitOfWork.Repository<EventRepository>();

            var @event = await repo!.GetEventWithAttendeesAsync(request.EventId);

            if(@event is null)
            {
                response.Successfull = false;
                response.Message = $"Error setting attendance for event.Could not find event for event id: {request.EventId}.";
            }

            @event!.SetAttending(request.EmailAddress, request.Attending);

            await repo.UpdateAsync(@event);

            await _unitOfWork.SaveChangesAsync();

            response.Successfull = true;
            response.Message = $"Attendance for attendee: {request.EmailAddress} has been set successfully.";
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = $"An unexpected error has occurred while trying to set the attandance for attendee: {request.EmailAddress} for event: {request.EventId}.";
        }

        return response;
    }

    public async Task<GetEventsResponse> GetEventsAsyns(DateTime? startTime, DateTime? endTime)
    {
        var response = new GetEventsResponse();

        try
        {
            var repo = _unitOfWork.Repository<EventRepository>();

            var events = await repo!.GetEventsWithAttendeesAsync(e => e.StartTime >= startTime!.Value && e.EndTime <= endTime!.Value);

            response.Successfull = true;
            response.Response = _mapper.Map<List<EventDto>>(events);



        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = $"An unexpected error has occurred while trying to retreive the events.";
        }

        return response;
    }
}
