using Microsoft.Extensions.Configuration;

namespace DevicesManager.Client
{
    internal class AppConfiguration
    {
        public static string GetServerHubUrl()
        {
            var config = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json", false, true)
                 .Build();

            var serverHubUrl = config.GetSection("ServerHubUrl")?.Value;
            return serverHubUrl ?? throw new Exception($"The server Hub url not found");
        }
    }
}
