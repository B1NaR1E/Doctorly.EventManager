using Doctorly.EventManager.Api.DTOs.Attendee;
using FluentValidation;

namespace Doctorly.EventManager.Api.Validators.Attendee;

public class CreateAttendeeRequestValidator : AbstractValidator<CreateAttendeeRequest>
{
    public CreateAttendeeRequestValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().NotNull().WithMessage("First name is require.");
        RuleFor(c => c.FirstName).MaximumLength(20).WithMessage("First name cannot exceed more than 20 characters");

        RuleFor(c => c.LastName).NotEmpty().NotNull().WithMessage("Last name is require.");
        RuleFor(c => c.LastName).MaximumLength(20).WithMessage("Last name cannot exceed more than 20 characters");

        RuleFor(c => c.EmailAddress).EmailAddress().WithMessage("Not a valid email address.");
        RuleFor(c => c.EmailAddress).MaximumLength(50).WithMessage("Enail address cannot exceed more than 50 characters");
    }
}
