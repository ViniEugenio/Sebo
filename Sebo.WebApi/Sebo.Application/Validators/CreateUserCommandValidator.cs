using FluentValidation;
using Sebo.Application.Commands.CreateUser;
using Sebo.Core.Helpers.Messages;

namespace Sebo.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage(UserMessages.EmailNotInformed);

            RuleFor(p => p.UserName)
                .MaximumLength(12)
                .MinimumLength(4)
                .WithMessage(UserMessages.UserNameInvalidLenght);

            RuleFor(p => p.Password)
                .MinimumLength(6)
                .WithMessage(UserMessages.PasswordNotInformedRegister);

            RuleFor(p => p.ConfirmPassword)
                .Must((model, field) => field.Equals(model.Password))
                .WithMessage(UserMessages.DifferentPasswords);

        }
    }
}
