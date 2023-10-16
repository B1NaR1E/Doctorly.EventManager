using Doctorly.EventManager.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Events;

public partial class Attendee : IValueObject
{
    public Attendee(string firstName, string lastName, string emailAddress, int eventId, bool isAttending = false)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        EventId = eventId;
        IsAttending = isAttending;
        Event = new Event();
    }

    [Required]
    [StringLength(20)]
    public string FirstName { get; }

    [Required]
    [StringLength(20)]
    public string LastName { get; }

    [Required]
    [StringLength(50)]
    public string EmailAddress { get; }

    public bool IsAttending { get; set; }

    [Required]
    public int EventId { get; }

    public Event Event { get; }
}
