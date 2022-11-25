using DevicesManager.Client.Model;

namespace DevicesManager.Client
{
    internal interface ICurrentDeviceService
    {
        DeviceDto GetDeviceInformation();
    }
}