using APITesting.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APITesting.Data
{
    public class APIRequest
    {
        public async Task<HttpResponseMessage> CreateNewUserAsync(CreateUserRequest createUserRequest)
        {
            var httpClient = new HttpClient();

            var envPath = Path.Combine("Data", "Utils.json");
            var serialized = JsonConvert.SerializeObject(createUserRequest);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            var deserializeEnv = JsonConvert.DeserializeObject<EndpointModel>(envPath);

            return await httpClient.PostAsync(deserializeEnv.endpoint, stringContent);
        }
    }
}
