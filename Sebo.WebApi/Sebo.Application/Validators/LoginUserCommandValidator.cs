using FluentValidation;
using Sebo.Application.Commands.LoginUser;
using Sebo.Core.Helpers.Messages;

namespace Sebo.Application.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {

        public LoginUserCommandValidator()
        {

            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(UserMessages.EmailNotInformed);

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage(UserMessages.PasswordNotInformed);

        }

    }
}
