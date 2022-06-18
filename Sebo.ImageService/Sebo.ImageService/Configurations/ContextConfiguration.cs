using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sebo.ImageService.Persistence;

namespace Sebo.ImageService.Configurations
{
    public static class ContextConfiguration
    {

        public static void ContextConfigure(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("MainConnection")));
        }

    }
}
