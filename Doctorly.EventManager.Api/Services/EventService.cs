using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Api.Validators.Event;
using Doctorly.EventManager.Domain.Events;
using Doctorly.EventManager.Infrastructure.Data;

namespace Doctorly.EventManager.Api.Services;

public class EventService : BaseService, IEventService
{
    private readonly IUnitOfWork _unitOfWork;

    public EventService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateEventResponse> CreateEventAsync(CreateEventRequest request)
    {
        var response = new CreateEventResponse();
        var validator = new CreateEventRequestValidator();

        try
        {
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }

            var eventRepository = _unitOfWork.Repository<Event>();
            var result = await eventRepository.AddAsync(new Event(request.Title, request.Description, request.StartTime, request.EndTime));
            response.Successfull = true;
            response.Response = result;
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = "An unexpected error has occurred while trying to create an event.";
        }

        return response;
    }
}
