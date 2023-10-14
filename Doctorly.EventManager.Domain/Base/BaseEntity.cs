﻿namespace Doctorly.EventManager.Domain.Base;

public abstract class BaseEntity
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

public abstract class BaseEntity<TKey> : BaseEntity
{
    public TKey Id { get; set; }
}