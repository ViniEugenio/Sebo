using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Sebo.Application.Commands.CreateUser;
using Sebo.Application.Commands.LoginUser;
using Sebo.Application.Queries.ListUsers;
using Sebo.Application.Queries.UserDetail;
using Sebo.Core.Helpers.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace Sebo.WebApi.Controllers
{
    [Route("api/user")]
    [Authorize]
    public class UserController : Controller
    {

        private readonly IMediator Mediator;

        public UserController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new ListUsersQuery()));
        }

        [HttpGet("Detail/{UserId}")]
        public async Task<IActionResult> Detail(string UserId)
        {

            var FoundedUser = await Mediator.Send(new UserDetailQuery(UserId));

            if (FoundedUser == null)
            {

                return NotFound(new
                {
                    Errors = UserMessages.UserNotFound
                });

            }

            return Ok(FoundedUser);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {

            var result = await Mediator.Send(command);

            if (!result.Succeeded)
            {

                return BadRequest(new
                {
                    Errors = result.Errors.Select(error => error.Description).ToList()
                });

            }

            return Ok(new
            {
                Message = UserMessages.UserCreated
            });

        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {

            var result = await Mediator.Send(command);

            if (string.IsNullOrEmpty(result.Token))
            {

                return BadRequest(new
                {
                    Error = result.Message
                });

            }

            return Ok(result);

        }

    }
}
