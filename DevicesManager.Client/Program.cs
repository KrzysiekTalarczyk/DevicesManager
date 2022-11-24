// See https://aka.ms/new-console-template for more information
using DevicesManager.Client;

var service = new CurrentDeviceService();
var info = service.GetDeviceInformation();