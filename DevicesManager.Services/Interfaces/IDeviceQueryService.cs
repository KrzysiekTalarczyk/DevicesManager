using DevicesManager.Dtos.Requests;
using DevicesManager.Dtos.Response;

namespace DevicesManager.Services.Interfaces
{
    public interface IDeviceQueryService
    {
        Task<FilteredResponse<DeviceDto>> GetDevices(GetAllDevicesRequestDto query);
        Task<DeviceDto> GetDevice(int id);
    }
}
