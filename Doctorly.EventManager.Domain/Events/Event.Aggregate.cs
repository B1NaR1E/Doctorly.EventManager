using Doctorly.EventManager.Domain.Base;
using Doctorly.EventManager.Domain.Shared;

namespace Doctorly.EventManager.Domain.Events;

public partial class Event : IAggregateRoot
{
    public Event()
    {
        EventAttendees = new List<EventAttendee>();
        EventStatus = EventStatus.Open;
    }

    public void SetEventInfo(string title, string? description, DateTime startTime, DateTime endTime)
    {
        Title = title;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
    }

    public void AddAttendee(int attendeeId)
    {
        EventAttendees.Add(new EventAttendee() { AttendeeId = attendeeId });
    }

    public void RemoveAttendee(EventAttendee attendee)
    {
        EventAttendees.Remove(attendee);
    }

    public void Cancel()
    {
        EventStatus = EventStatus.Cancelled;
    }

    public void SetAttending(int attendeeId, bool isAttending)
    {
        var attendee = EventAttendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
        attendee!.IsAttending = isAttending;
    }
}
