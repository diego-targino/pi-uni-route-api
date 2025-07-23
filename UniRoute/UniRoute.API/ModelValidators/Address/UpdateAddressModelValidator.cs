using FluentValidation;
using UniRoute.API.Model.Address;
using UniRoute.Domain.Messages;

namespace UniRoute.API.ModelValidators.Address;

public class UpdateAddressModelValidator : AbstractValidator<UpdateAddressModel>
{
    public UpdateAddressModelValidator()
    {
        RuleFor(model => model.Street)
            .MaximumLength(150)
            .When(model => !string.IsNullOrWhiteSpace(model.Street))
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.Street), 150));

        RuleFor(model => model.PostalCode)
            .MaximumLength(8)
            .When(model => !string.IsNullOrWhiteSpace(model.PostalCode))
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.PostalCode), 8));
    }
}
