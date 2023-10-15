using Doctorly.EventManager.Domain.Base.Events;
using Doctorly.EventManager.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Events;

public partial class Event : EventBase
{
    [Required]
    public EventStatus EventStatus { get; protected set; }

    public List<EventAttendee> EventAttendees { get; protected set; }
}
