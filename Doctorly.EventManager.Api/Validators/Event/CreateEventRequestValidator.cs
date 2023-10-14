using Doctorly.EventManager.Api.DTOs.Event;
using FluentValidation;

namespace Doctorly.EventManager.Api.Validators.Event
{
    public class CreateEventRequestValidator : AbstractValidator<CreateEventRequest>
    {
        public CreateEventRequestValidator()
        {
            RuleFor(e => e.Title).NotEmpty().NotNull().WithMessage("The event title is required and connot be empty or null.");
            RuleFor(e => e.Title).MaximumLength(50).WithMessage("The event title cannot exceed more than 50 characters.");

            RuleFor(e => e.Description).MaximumLength(250).WithMessage("The event discription cannot exceed more than 250 characters");

            RuleFor(e => e.StartTime).LessThanOrEqualTo(DateTime.Now).WithMessage("Event start time cannot be in the past.");

            RuleFor(e => e.EndTime).LessThanOrEqualTo(DateTime.Now).WithMessage("Event end time cannot be in the past.");
            RuleFor(e => e.EndTime).LessThanOrEqualTo(e => e.StartTime).WithMessage("Event end time cannot take place before the start time.");
        }
    }
}
