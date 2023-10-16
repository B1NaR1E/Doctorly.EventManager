using Doctorly.EventManager.Api.DTOs.Attendee;

namespace Doctorly.EventManager.Api.DTOs.Event;

public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<AttendeeDto> Attendees { get; set; }
}
