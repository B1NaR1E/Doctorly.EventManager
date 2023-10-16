using Doctorly.EventManager.Domain.Events;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            .Include(ea => ea.Attendees)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Event>> GetEventsWithAttendeesAsync(Expression<Func<Event, bool>> expression)
    {
        return await _context.Events
            .Where(expression)
            .Include(ea => ea.Attendees)
            .ToListAsync();
    }
}
