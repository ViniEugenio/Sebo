using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sebo.Core.Entities;
using Sebo.Infrastructure.Persistence;

namespace Sebo.WebApi.Configurations
{
    public static class IdentityConfiguration
    {

        public static void ConfigureIdentity(this IServiceCollection service)
        {

            service.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<SeboDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<IdentityMessagesConfiguration>();

        }

    }
}
