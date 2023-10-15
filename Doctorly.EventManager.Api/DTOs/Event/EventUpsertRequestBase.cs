using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Api.DTOs.Event
{
    public abstract class EventUpsertRequestBase
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public List<int> AttendeeIds { get; set; }
    }
}
