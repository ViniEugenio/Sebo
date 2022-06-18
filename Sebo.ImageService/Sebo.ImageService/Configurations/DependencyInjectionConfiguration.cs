using Microsoft.Extensions.DependencyInjection;
using Sebo.ImageService.Consumers;
using Sebo.ImageService.Persistence.Interfaces;
using Sebo.ImageService.Persistence.Repositories;
using Sebo.ImageService.Services;

namespace Sebo.ImageService.Configurations
{
    public static class DependencyInjectionConfiguration
    {

        public static void DependencyInjectionConfigure(this IServiceCollection services)
        {
            services.AddHostedService<ProcessUploadImageConsumer>();
            services.AddScoped<IImageService, Services.ImageService>();
            services.AddScoped<IFileRepository, FileRepository>();
        }

    }
}
