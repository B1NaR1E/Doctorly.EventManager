using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Base.Events;

public abstract class EventBase : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Title { get; protected set; }

    [StringLength(250)]
    public string? Description { get; protected set; }

    [Required]
    public DateTime StartTime { get; protected set; }

    [Required]
    public DateTime EndTime { get; protected set; }
}
