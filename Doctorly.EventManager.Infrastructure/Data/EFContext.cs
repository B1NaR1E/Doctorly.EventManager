using Doctorly.EventManager.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.EventManager.Infrastructure.Data;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<EventAttendee> EventAttendees { get; set; }
}
