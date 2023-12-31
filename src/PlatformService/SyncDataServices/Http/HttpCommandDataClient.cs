using PlatformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        public readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        // create a method to delete Platform
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );
            
            // var response = await _httpClient.PostAsync($"{_config["CommandService"]}", httpContent);
            //var response = await _httpClient.PostAsync("http://localhost:6000/api/c/Platforms", httpContent);
            //"http://commands-clusterip-srv:80/api/c/platforms"
            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK!");
            }
            else
            {
                Console.WriteLine(@$"
                --> Sync POST to CommandService was NOT OK! 
                 StatusCode:{response.StatusCode} 
                 response.Content: {response.Content.ReadAsStringAsync()}");
            }

        }

    }
}