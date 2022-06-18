using Microsoft.Extensions.DependencyInjection;
using Sebo.Core.Repositories;
using Sebo.Core.Services;
using Sebo.Infrastructure.Auth;
using Sebo.Infrastructure.ExternalServices;
using Sebo.Infrastructure.MicroServices;
using Sebo.Infrastructure.MicroServices.MessageBus;
using Sebo.Infrastructure.Persistence.Repositories;

namespace Sebo.WebApi.Configurations
{
    public static class DependenciesInjectionConfiguration
    {
        public static void DependenciesInjectionConfigure(this IServiceCollection services)
        {

            services.AddScoped<IMangaRepository, MangaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IImageAPIService, ImageAPIService>();

        }
    }
}
