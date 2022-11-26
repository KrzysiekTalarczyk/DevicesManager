using DevicesManager.Client;

Console.WriteLine("Device Manager Client starts work.");

var serverHubUrl = AppConfiguration.GetServerHubUrl();
var hub = new DeviceHubService(serverHubUrl);
var service = new CurrentDeviceService();
var info = service.GetDeviceInformation();
Console.WriteLine($"Collecting iformation about current device: {info}");
await hub.StartAsync();
Console.WriteLine($"Connect with: {serverHubUrl}");
await hub.SendDeviceInformarion(info);
Console.WriteLine($"Send information about device to server");
Console.ReadKey();
