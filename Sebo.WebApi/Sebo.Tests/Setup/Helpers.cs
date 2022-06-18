using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Sebo.Infrastructure.Persistence;
using Sebo.WebApi;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sebo.Tests.Setup
{
    public static class Helpers
    {

        public static WebApplicationFactory<Startup> Build(this WebApplicationFactory<Startup> factory)
        {

            string ConnectionString = $"Server=localhost;Database={Guid.NewGuid()};Trusted_Connection=True;";

            return factory.WithWebHostBuilder(builder =>
            {

                builder.ConfigureServices(services =>
                {

                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<SeboDbContext>));

                    services.Remove(descriptor);

                    services.AddDbContext<SeboDbContext>(options =>
                    {
                        options.UseSqlServer(ConnectionString);
                    });

                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {

                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<SeboDbContext>();
                        db.Database.EnsureCreated();

                    }

                });

            });

        }

        public static StringContent FormatBody<TBody>(TBody Body)
        {
            return new StringContent(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json");
        }

        public static async Task<TResponse> FormatResponse<TResponse>(HttpResponseMessage response)
        {
            string teste = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(teste);
        }

    }
}
