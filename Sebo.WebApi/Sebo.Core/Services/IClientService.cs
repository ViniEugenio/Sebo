using System.Net.Http;
using System.Threading.Tasks;

namespace Sebo.Core.Services
{
    public interface IClientService
    {
        Task<HttpResponseMessage> Get(string Endpoint);
    }
}

