using FluentValidation;
using UniRoute.API.Model.Student;
using UniRoute.Domain.Messages;

namespace UniRoute.API.ModelValidators.Student;

public class CreateStudentModelValidator : AbstractValidator<CreateStudentModel>
{
    public CreateStudentModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Name)));

        RuleFor(model => model.Name)
            .MaximumLength(150)
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.Name)));

        RuleFor(model => model.Mail)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Mail)));

        RuleFor(model => model.Mail)
            .MaximumLength(77)
            .WithMessage(model => string.Format(ValidationMessages.MaxLength, nameof(model.Mail)));

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ValidationMessages.Required, nameof(model.Password)));
    }
}
