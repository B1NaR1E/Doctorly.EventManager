using AutoMapper;
using Doctorly.EventManager.Api.DTOs.Attendee;
using Doctorly.EventManager.Api.Validators.Attendee;
using Doctorly.EventManager.Domain.Events;
using Doctorly.EventManager.Infrastructure.Data.Repositries;

namespace Doctorly.EventManager.Api.Services;

public class AttendeeService : IAttendeeService
{
    private readonly AttendeeRepository _repository;
    private readonly IMapper _mapper;

    public AttendeeService(AttendeeRepository repository, IMapper eventMapper)
    {
        _repository = repository;
        _mapper = eventMapper;
    }

    public async Task<CreateAttendeeResponse> CreateAttendeeAsync(CreateAttendeeRequest request)
    {
        var response = new CreateAttendeeResponse();
        var validator = new CreateAttendeeRequestValidator();

        try
        {
             var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }

            var attendee = new Attendee();
            attendee.SetAttendeeInfo(request.FirstName, request.LastName, request.EmailAddress);

            var result = await _repository.AddAsync(attendee);
            await _repository.SaveChangesAsync();

            response.Successfull = true;

            response.Response = _mapper.Map<AttendeeDto>(result);
        }
        catch (Exception)
        {
            response.Successfull = false;
            response.Message = "An unexpected error has occurred while trying to create an attendee.";
        }

        return response;
    }
}
