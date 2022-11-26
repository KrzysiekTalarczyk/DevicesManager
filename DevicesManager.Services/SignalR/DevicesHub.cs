using DevicesManager.Dtos.Response;
using DevicesManager.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace DevicesManager.Services.SignalR
{
    public class DevicesHub : Hub
    {
        private readonly IDeviceCommandService _deviceCommandService;
        public DevicesHub(IDeviceCommandService deviceCommandService)
        {
            _deviceCommandService = deviceCommandService;
        }

        public async Task SendDeviceInfo(DeviceDto dto)
        {
            dto.ConnectionId = Context.ConnectionId;
            await _deviceCommandService.AddAsync(dto);
        }
    }
}
