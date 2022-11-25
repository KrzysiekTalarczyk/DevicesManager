using DevicesManager.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;


var serverHubUrl = AppConfiguration.GetServerHubUrl();
var service = new CurrentDeviceService();
var info = service.GetDeviceInformation();

var connection = new HubConnectionBuilder()
                     .WithUrl(serverHubUrl)
                     .Build();

connection.StartAsync().Wait();
connection.InvokeCoreAsync("SendDeviceInfo", args: new[] { info });