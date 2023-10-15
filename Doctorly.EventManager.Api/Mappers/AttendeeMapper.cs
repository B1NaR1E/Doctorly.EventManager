using AutoMapper;
using Doctorly.EventManager.Api.DTOs.Attendee;
using Doctorly.EventManager.Domain.Events;

namespace Doctorly.EventManager.Api.Mappers;

public class AttendeeMapper : Profile
{
    public AttendeeMapper()
    {
        CreateMap<EventAttendee, AttendeeDto>()
            .ForMember(c => c.AttendeeId, act => act.MapFrom(s => s.AttendeeId))
            .ForMember(c => c.FirstName, act => act.MapFrom(s => s.Attendee.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(s => s.Attendee.LastName))
            .ForMember(c => c.EmailAddress, act => act.MapFrom(s => s.Attendee.EmailAddress))
            .ForMember(c => c.Attending, act => act.MapFrom(s => s.IsAttending));

        CreateMap<Attendee, AttendeeDto>()
            .ForMember(c => c.AttendeeId, act => act.MapFrom(s => s.Id));
    }
}
