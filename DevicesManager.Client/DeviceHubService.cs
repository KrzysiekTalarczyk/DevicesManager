using DevicesManager.Client.Model;
using Microsoft.AspNetCore.SignalR.Client;

namespace DevicesManager.Client
{
    public class DeviceHubService
    {
        private readonly HubConnection connection;

        public DeviceHubService(string serverHubUrl)
        {
            connection = new HubConnectionBuilder()
                     .WithUrl(serverHubUrl)
                     .Build();
            connection.On<string>("CloseClient",
                       async connectionId =>
                       {
                           await connection.StopAsync();
                           Console.WriteLine($"Client with connectionId {connectionId} closed by server request.");
                       });
        }

        public async Task StartAsync()
        {
            await connection.StartAsync();
        }

        public async Task SendDeviceInformarion(DeviceDto deviceInfo)
        {
            await connection.InvokeCoreAsync("SendDeviceInfo", args: new[] { deviceInfo });
        }
    }
}
