using Doctorly.EventManager.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.EventManager.Infrastructure.Data;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventAttendee>()
            .HasOne(e => e.Event)
            .WithMany(e => e.EventAttendees)
            .HasForeignKey(e => e.EventId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<EventAttendee>()
            .HasOne(e => e.Attendee)
            .WithMany(e => e.AttendeeEvents)
            .HasForeignKey(e => e.AttendeeId)
            .HasPrincipalKey(e => e.Id);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<EventAttendee> EventAttendees { get; set; }
}
