using MediatR;
using Microsoft.AspNetCore.Identity;
using Sebo.Application.ViewModels.UserViewModels;
using Sebo.Core.Entities;
using Sebo.Core.Helpers.Messages;
using Sebo.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Commands.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {

        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;
        private readonly IAuthService AuthService;

        public LoginUserCommandHandler(UserManager<User> UserManager, SignInManager<User> SignInManager, IAuthService AuthService)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
            this.AuthService = AuthService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            var FoundedUser = await UserManager.FindByEmailAsync(request.Email);
            if (FoundedUser == null)
            {
                return new LoginUserViewModel(UserMessages.LoginNotFound, null);
            }

            var result = await SignInManager.PasswordSignInAsync(FoundedUser, request.Password, request.IsPersistence, false);

            if (!result.Succeeded)
            {
                return new LoginUserViewModel(UserMessages.IncorrectPassword, null);
            }

            return new LoginUserViewModel(UserMessages.LoginSuccess, AuthService.GenerateJWTToken(request.Email, "User"));

        }
    }
}
