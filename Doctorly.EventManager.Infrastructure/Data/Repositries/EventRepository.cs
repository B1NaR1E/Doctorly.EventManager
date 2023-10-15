using Doctorly.EventManager.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.EventManager.Infrastructure.Data.Repositries;

public class EventRepository : RepositoryBase<Event>
{
    private readonly EFContext _context;
    public EventRepository(EFContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Event?> GetEventWithAttendeesAsync(int eventId)
    {
        return await _context.Events
            .Where(e => e.Id == eventId)
            .Include(e => e.EventAttendees)
            .ThenInclude(ea => ea.Attendee)
            .FirstOrDefaultAsync();
    }
}
