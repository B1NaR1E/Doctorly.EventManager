using Doctorly.EventManager.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Events;

public partial class Attendee : BaseEntity
{
    [Required]
    [StringLength(20)]
    public string FirstName { get; protected set; }

    [Required]
    [StringLength(20)]
    public string LastName { get; protected set; }

    [Required]
    [StringLength(50)]
    public string EmailAddress { get; protected set; }

    public List<EventAttendee> AttendeeEvents { get; set; }
}
