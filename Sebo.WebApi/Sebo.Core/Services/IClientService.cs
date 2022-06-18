using System.Threading.Tasks;

namespace Sebo.Core.Services
{
    public interface IClientService
    {
        Task<T> Get<T>(string Endpoint);
    }
}

