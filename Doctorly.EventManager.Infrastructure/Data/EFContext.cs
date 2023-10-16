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

        modelBuilder.Entity<Attendee>().HasKey(a => new { a.EventId, a.EmailAddress });
        modelBuilder.Entity<Attendee>().Property(a => a.FirstName);
        modelBuilder.Entity<Attendee>().Property(a => a.LastName);

        modelBuilder.Entity<Event>().HasMany(e => e.Attendees).WithOne(a => a.Event);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}
