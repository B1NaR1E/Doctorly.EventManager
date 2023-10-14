using Doctorly.EventManager.Domain.Events;

namespace Doctorly.EventManager.Infrastructure.Data.Repositries;

public class EventRepository : RepositoryBase<Event>
{
    public EventRepository(EFContext context) : base(context)
    {
    }
}
