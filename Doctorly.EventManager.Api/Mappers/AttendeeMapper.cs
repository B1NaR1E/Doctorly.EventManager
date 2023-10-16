using AutoMapper;
using Doctorly.EventManager.Api.DTOs.Attendee;
using Doctorly.EventManager.Domain.Events;

namespace Doctorly.EventManager.Api.Mappers;

public class AttendeeMapper : Profile
{
    public AttendeeMapper()
    {
        CreateMap<Attendee, AttendeeDto>();
    }
}
