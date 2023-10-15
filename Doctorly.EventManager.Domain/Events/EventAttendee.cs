using Doctorly.EventManager.Domain.Base;

namespace Doctorly.EventManager.Domain.Events;

public class EventAttendee : BaseEntity
{
    public int AttendeeId { get; set; }
    public int EventId { get; set; }
    public bool IsAttending { get; set; }

    public Attendee Attendee { get; set; }
    public Event Event { get; set; }
}
