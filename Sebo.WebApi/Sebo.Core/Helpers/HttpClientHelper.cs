using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sebo.Core.Helpers
{
    public static class HttpClientHelper
    {

        public static async Task<T> FormatResponse<T>(HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<T>(await message.Content.ReadAsStringAsync());
        }

    }
}
