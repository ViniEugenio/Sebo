using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Sebo.Infrastructure.Persistence;
using Sebo.WebApi;
using System;

namespace Sebo.Tests.Setup
{
    public abstract class WebClientFactory : IDisposable
    {

        protected readonly WebApplicationFactory<Startup> Factory;

        public WebClientFactory()
        {

            var Factory = new WebApplicationFactory<Startup>().Build();
            this.Factory = Factory;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {

                using var _scope = Factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
                using var _context = _scope.ServiceProvider.GetRequiredService<SeboDbContext>();
                _context?.Database.EnsureDeleted();
                Factory.Dispose();

            }

        }

    }
}
