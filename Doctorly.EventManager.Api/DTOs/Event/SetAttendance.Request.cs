namespace Doctorly.EventManager.Api.DTOs.Event;

public class SetAttendanceRequest
{
    public int EventId { get; set; }
    public int AttendeeId { get; set; }
    public bool Attending {  get; set; }
}
