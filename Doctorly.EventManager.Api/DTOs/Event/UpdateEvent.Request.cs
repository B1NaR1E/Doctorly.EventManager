namespace Doctorly.EventManager.Api.DTOs.Event;

public class UpdateEventRequest : EventUpsertRequestBase
{
    public int Id { get; set; }
}
