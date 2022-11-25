//using DevicesManager.Dtos.Response;
//using DevicesManager.Services.Interfaces;
//using Microsoft.AspNetCore.SignalR;

//namespace DevicesManager.Server.SignalR
//{
//    public class DevicesHub : Hub //, IClientService
//    {
//        private readonly IDeviceCommandService _deviceCommandService;
//        public DevicesHub(IDeviceCommandService deviceCommandService)
//        {
//            _deviceCommandService = deviceCommandService;
//        }

//        public async Task SendDeviceInfo(DeviceDto dto)
//        {
//            dto.ConectionId = Context.ConnectionId;
//           await _deviceCommandService.AddAsync(dto);
//        }

//        public async Task CloseClient(string connectionId)
//        {
//            await Clients.Client(connectionId).SendAsync("closeClient");
//        }
//    }

//    public interface IClientService
//    {
//        Task CloseClient(string connectionId);
//    }
//}
