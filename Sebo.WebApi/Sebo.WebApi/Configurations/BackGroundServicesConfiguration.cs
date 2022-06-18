using Microsoft.Extensions.DependencyInjection;
using Sebo.Application.Consumers;

namespace Sebo.WebApi.Configurations
{
    public static class BackGroundServicesConfiguration
    {

        public static void BackGroundServicesConfigure(this IServiceCollection services)
        {
            services.AddHostedService<ImageConsumer>();
        }

    }
}
