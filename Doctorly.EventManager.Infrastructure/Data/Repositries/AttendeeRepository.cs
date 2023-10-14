using Doctorly.EventManager.Domain.Events;

namespace Doctorly.EventManager.Infrastructure.Data.Repositries;

internal class AttendeeRepository : RepositoryBase<Attendee>
{
    public AttendeeRepository(EFContext context) : base(context)
    {
    }
}
