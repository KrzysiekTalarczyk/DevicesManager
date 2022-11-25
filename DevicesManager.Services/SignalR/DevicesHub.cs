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

          //  await Clients.Client(dto.ConnectionId).SendAsync("CloseClient", "message");
        }
    }

    public class ClientService : IClientService
    {
        private readonly IHubContext<DevicesHub> _hub;

        public ClientService(IHubContext<DevicesHub> hub)
        {
            _hub = hub;
        }

        public async Task CloseClient(string connectionId)
        {
            await _hub.Clients.Client(connectionId).SendAsync("CloseClient", connectionId);
        }
    }

    public interface IClientService
    {
        Task CloseClient(string connectionId);
    }
}
