using DevicesManager.Client;
using Microsoft.AspNetCore.SignalR.Client;

var serverHubUrl = AppConfiguration.GetServerHubUrl();
var service = new CurrentDeviceService();
var info = service.GetDeviceInformation();
var running = true;
var connection = new HubConnectionBuilder()
                     .WithUrl(serverHubUrl)
                     .Build();

connection.On<string>("CloseClient",
    async connectionId =>
    {
        await connection.StopAsync();
        Console.WriteLine($"Client with connectionId {connectionId} closed");
        running = false;
    });

await connection.StartAsync();

await connection.InvokeCoreAsync("SendDeviceInfo", args: new[] { info });

while (running) { }
Console.ReadKey();
