using Microsoft.AspNetCore.SignalR;

namespace DevicesManager.Services.SignalR
{
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
}
