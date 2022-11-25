using DevicesManager.Dtos.Response;

namespace DevicesManager.Services.Interfaces
{
    public interface IDeviceCommandService
    {
        Task AddAsync(DeviceDto dto);
        Task DeleteDevice(int id);
    }
}
