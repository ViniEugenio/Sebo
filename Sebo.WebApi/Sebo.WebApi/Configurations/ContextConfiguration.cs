using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sebo.Infrastructure.Persistence;

namespace Sebo.WebApi.Configurations
{
    public static class ContextConfiguration
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<SeboDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MainConnection")));
        }
    }
}
