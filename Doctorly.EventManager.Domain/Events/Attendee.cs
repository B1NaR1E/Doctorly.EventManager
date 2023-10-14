using Doctorly.EventManager.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Events;

public class Attendee : BaseEntity
{
    [Required]
    [StringLength(20)]
    public string FirstName { get; }

    [Required]
    [StringLength(20)]
    public string LastName { get; }

    [Required]
    [StringLength(50)]
    public string EmailAddress { get; }

    public virtual List<Event> Events { get; set; }
}
