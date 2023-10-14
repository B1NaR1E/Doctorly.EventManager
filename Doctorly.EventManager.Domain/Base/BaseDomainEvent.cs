namespace Doctorly.EventManager.Domain.Base;

public abstract class BaseDomainEvent
{
    public BaseDomainEvent()
    {
        EventId = Guid.NewGuid();
        CreatedOn = DateTime.Now;
    }

    public virtual Guid EventId { get; init; }
    public virtual DateTime CreatedOn { get; init;}
}
