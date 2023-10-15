namespace Doctorly.EventManager.Domain.Events;

public partial class Attendee
{
    public Attendee()
    {
        AttendeeEvents = new List<EventAttendee>();
    }

    public void SetAttendeeInfo(string firstName, string lastName, string emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }
}
