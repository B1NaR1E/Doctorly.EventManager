using AutoMapper;
using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Domain.Events;

namespace Doctorly.EventManager.Api.Mappers;

public class EventMapper : Profile
{
    public EventMapper()
    {
        CreateMap<Event, EventDto>().ForMember(e => e.Attendees, act => act.Ignore());
    }
}
