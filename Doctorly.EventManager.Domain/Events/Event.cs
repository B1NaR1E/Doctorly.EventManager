using Doctorly.EventManager.Domain.Base;
using Doctorly.EventManager.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Events;

public partial class Event : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Title { get; }

    [StringLength(250)]
    public string? Description { get; }

    [Required]
    public DateTime StartTime { get; }

    [Required]
    public DateTime EndTime { get; }

    [Required]
    public EventStatus EventStatus { get; } = EventStatus.Open;

    public virtual List<Attendee> Attendees { get; }
}
