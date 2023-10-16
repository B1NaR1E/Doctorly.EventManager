using Doctorly.EventManager.Domain.Base;
using Doctorly.EventManager.Domain.Shared;

namespace Doctorly.EventManager.Domain.Events;

public partial class Event : IAggregateRoot
{
    public Event()
    {
        Attendees = new List<Attendee>();
        EventStatus = EventStatus.Open;
    }

    public void SetEventInfo(string title, string? description, DateTime startTime, DateTime endTime)
    {
        Title = title;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
    }

    public void AddAttendee(string firstName, string lastName, string emailAddress, bool isAttending = false)
    {
        Attendees.Add(new Attendee(firstName, lastName, emailAddress, Id));
    }

    public void RemoveAttendee(Attendee attendee)
    {
        Attendees.Remove(attendee);
    }

    public void Cancel()
    {
        EventStatus = EventStatus.Cancelled;
    }

    public void SetAttending(string emailAddress , bool isAttending)
    {
        var attendee = Attendees.FirstOrDefault(a => a.EventId == Id && a.EmailAddress == emailAddress);
        attendee!.IsAttending = isAttending;
    }
}
