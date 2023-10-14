using Doctorly.EventManager.Domain.Base;

namespace Doctorly.EventManager.Domain.Events;

public class EventAttendee : BaseEntity
{
    public int AttendeeId { get; set; }
    public int EventId { get; set; }
    public bool IsAttending { get; set; }

    public virtual Attendee Attendee { get; set; }
    public virtual Event Event { get; set; }
}
