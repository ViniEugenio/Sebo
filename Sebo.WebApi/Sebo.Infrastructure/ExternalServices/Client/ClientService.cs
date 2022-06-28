using Sebo.Core.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sebo.Infrastructure.ExternalServices.Client
{
    public class ClientService : IClientService
    {

        private readonly HttpClient Client;

        public ClientService(string BaseAddress)
        {

            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseAddress);

        }

        public async Task<HttpResponseMessage> Get(string Endpoint)
        {
            return await Client.GetAsync(Endpoint);
        }

    }
}
