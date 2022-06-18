using Bogus;
using FluentAssertions;
using Sebo.Application.Commands.CreateUser;
using Sebo.Application.Commands.LoginUser;
using Sebo.Application.ViewModels.UserViewModels;
using Sebo.Core.Helpers.Messages;
using Sebo.Tests.Setup;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Sebo.Tests.Tests
{
    public class UserTests : BaseTest
    {

        #region Auxiliar Classes

        private class BadRequestResponse
        {
            public List<string> errors { get; set; }
        }

        private class BadRequestResponseMessage
        {
            public string error { get; set; }
        }

        private class SuccessResponse
        {
            public string message { get; set; }
        }

        #endregion

        [Fact]
        public async Task ProcessOfUserCreationTest()
        {

            var NewUser = new CreateUserCommand()
            {
                ConfirmPassword = "Test",
                Email = "Test",
                Password = "Test",
                UserName = "T"
            };

            var result = await Post(RouterRegister.CreateUser, NewUser);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var BadRequest = await Helpers.FormatResponse<BadRequestResponse>(result);
            BadRequest.Should().BeEquivalentTo(new BadRequestResponse()
            {
                errors = new List<string>()
                {
                    UserMessages.EmailNotInformed,
                    UserMessages.PasswordNotInformedRegister,
                    UserMessages.UserNameInvalidLenght
                }
            });

            var Faker = new Faker();
            NewUser.UserName = "Test";
            NewUser.Email = Faker.Person.Email;
            NewUser.Password = "Test@123";

            result = await Post(RouterRegister.CreateUser, NewUser);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            BadRequest = await Helpers.FormatResponse<BadRequestResponse>(result);
            BadRequest.Should().BeEquivalentTo(new BadRequestResponse()
            {
                errors = new List<string>()
                {
                    UserMessages.DifferentPasswords
                }
            });

            NewUser.ConfirmPassword = NewUser.Password;

            result = await Post(RouterRegister.CreateUser, NewUser);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var SuccessResponse = await Helpers.FormatResponse<SuccessResponse>(result);
            SuccessResponse.Should().BeEquivalentTo(new SuccessResponse()
            {
                message = UserMessages.UserCreated
            });

            result = await Post(RouterRegister.CreateUser, NewUser);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            BadRequest = await Helpers.FormatResponse<BadRequestResponse>(result);
            BadRequest.Should().BeEquivalentTo(new BadRequestResponse()
            {
                errors = new List<string>()
                {
                    $"O login '{NewUser.UserName}' já está sendo utilizado."
                }
            });

        }

        [Fact]
        public async Task LoginUserAndVerifyJWTAutheticityTest()
        {

            var NewUser = new CreateUserCommand()
            {
                ConfirmPassword = "Test@123",
                Email = "test@test.com",
                Password = "Test@123",
                UserName = "Test"
            };

            var result = await Post(RouterRegister.CreateUser, NewUser);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var SuccessResponse = await Helpers.FormatResponse<SuccessResponse>(result);
            SuccessResponse.Should().BeEquivalentTo(new SuccessResponse()
            {
                message = UserMessages.UserCreated
            });

            var LoginModel = new LoginUserCommand()
            {
                Email = $"wrong{NewUser.Email}",
                IsPersistence = false,
                Password = $"wrong{NewUser.Password}"
            };

            result = await Post(RouterRegister.LoginUser, LoginModel);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var BadRequest = await Helpers.FormatResponse<BadRequestResponseMessage>(result);
            BadRequest.Should().BeEquivalentTo(new BadRequestResponseMessage()
            {
                error = UserMessages.LoginNotFound
            });

            LoginModel.Email = NewUser.Email;

            result = await Post(RouterRegister.LoginUser, LoginModel);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            BadRequest = await Helpers.FormatResponse<BadRequestResponseMessage>(result);
            BadRequest.Should().BeEquivalentTo(new BadRequestResponseMessage()
            {
                error = UserMessages.IncorrectPassword
            });

            LoginModel.Password = NewUser.Password;

            result = await Post(RouterRegister.LoginUser, LoginModel);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var LoginSuccessResponse = await Helpers.FormatResponse<LoginUserViewModel>(result);
            LoginSuccessResponse.Message.Should().BeEquivalentTo(UserMessages.LoginSuccess);

        }

    }
}
