namespace Doctorly.EventManager.Domain.Base;

public abstract class BaseEntity : BaseEntity<int>
{
    private readonly List<BaseDomainEvent> _events;
    public IReadOnlyList<BaseDomainEvent> Events => _events.AsReadOnly();

    protected void AddEvent(BaseDomainEvent @event)
    {
        _events.Add(@event);
    }

    protected void RemoveEvent(BaseDomainEvent @event) 
    {
        _events.Remove(@event);
    }
}

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
}