using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sebo.WebApi.Configurations;

namespace Sebo.WebApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureApi();
            services.SwaggerConfigure();
            services.ConfigureContext(Configuration);
            services.ConfigureIdentity();
            services.JWTConfigure(Configuration);
            services.MediatRConfigure();
            services.DependenciesInjectionConfigure();
            services.AutoMapperConfigure();
            services.BackGroundServicesConfigure();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment Environment)
        {
            app.ConfigureAppApi(Environment);
        }

    }
}
