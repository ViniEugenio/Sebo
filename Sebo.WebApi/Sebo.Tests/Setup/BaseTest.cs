using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sebo.Tests.Setup
{
    public abstract class BaseTest : WebClientFactory
    {

        private readonly HttpClient Client;

        public BaseTest()
        {

            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });

        }

        protected async Task<HttpResponseMessage> Post<TBody>(string EndPoint, TBody Body)
        {
            return await Client.PostAsync(EndPoint, Helpers.FormatBody(Body));
        }

    }
}
