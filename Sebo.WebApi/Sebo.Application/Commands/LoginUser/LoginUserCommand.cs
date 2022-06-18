using MediatR;
using Sebo.Application.ViewModels;
using Sebo.Application.ViewModels.UserViewModels;

namespace Sebo.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistence { get; set; }
    }
}
