using Doctorly.EventManager.Domain.Base;

namespace Doctorly.EventManager.Domain.Events;

public partial class Event : IAggregateRoot
{
    public Event(string title, string? description, DateTime startTime, DateTime endTime)
    {
        Title = title;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
        Attendees = new List<Attendee>();
    }

    public void AddAttendee(Attendee attendee)
    {
        Attendees.Add(attendee);
    }

    public void AddAttendee(IEnumerable<Attendee> attendees)
    {
        Attendees.AddRange(attendees);
    }

    public void 
}
