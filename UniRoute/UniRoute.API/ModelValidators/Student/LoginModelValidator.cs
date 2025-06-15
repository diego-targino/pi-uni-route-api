using FluentValidation;
using UniRoute.API.Model.Student;
using UniRoute.Domain.Messages;

namespace UniRoute.API.ModelValidators.Student;

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(model => model.Mail)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Mail)));

        RuleFor(model => model.Mail)
            .MaximumLength(77)
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.Mail)));

        RuleFor(model => model.Mail)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage(ValidationMessages.InvalidMail);

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Password)));
    }
}
