using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sebo.Application.Commands.CreateUser;

namespace Sebo.WebApi.Configurations
{
    public static class MediatRConfiguration
    {
        public static void MediatRConfigure(this IServiceCollection service)
        {
            service.AddMediatR(typeof(CreateUserCommand));
        }
    }
}
