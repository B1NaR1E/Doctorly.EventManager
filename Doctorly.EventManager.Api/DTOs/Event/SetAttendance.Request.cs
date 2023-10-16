namespace Doctorly.EventManager.Api.DTOs.Event;

public class SetAttendanceRequest
{
    public int EventId { get; set; }
    public string EmailAddress { get; set; }
    public bool Attending {  get; set; }
}
