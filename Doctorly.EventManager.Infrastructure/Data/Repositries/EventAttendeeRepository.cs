using Doctorly.EventManager.Domain.Events;

namespace Doctorly.EventManager.Infrastructure.Data.Repositries;

public class EventAttendeeRepository : RepositoryBase<EventAttendee>
{
    public EventAttendeeRepository(EFContext context) : base(context)
    {
    }
}
