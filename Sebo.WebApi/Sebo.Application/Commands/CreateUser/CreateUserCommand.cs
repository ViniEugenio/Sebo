using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Sebo.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<IdentityResult>
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
