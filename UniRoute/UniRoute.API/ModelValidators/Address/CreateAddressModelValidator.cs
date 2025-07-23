using FluentValidation;
using UniRoute.API.Model.Address;
using UniRoute.Domain.Messages;

namespace UniRoute.API.ModelValidators.Address;

public class CreateAddressModelValidator : AbstractValidator<CreateAddressModel>
{
    public CreateAddressModelValidator()
    {
        RuleFor(model => model.StudentId)
            .NotNull()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.StudentId)));

        RuleFor(model => model.StudentId)
            .GreaterThanOrEqualTo(1)
            .WithMessage(model => string.Format(ValidationMessages.MinValue, nameof(model.StudentId), 1));

        RuleFor(model => model.Street)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Street)));

        RuleFor(model => model.Street)
            .MaximumLength(150)
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.Street), 150));

        RuleFor(model => model.PostalCode)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.PostalCode)));

        RuleFor(model => model.PostalCode)
            .MaximumLength(8)
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.PostalCode), 8));

        RuleFor(model => model.Latitude)
            .NotNull()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Latitude)));

        RuleFor(model => model.Longitude)
            .NotNull()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Longitude)));
    }
}
