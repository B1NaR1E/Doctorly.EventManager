namespace Doctorly.EventManager.Api.DTOs.Attendee;

public class AttendeeDto
{
    public int AttendeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public bool Attending { get; set; }
}
