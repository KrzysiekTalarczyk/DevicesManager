using Microsoft.AspNetCore.SignalR;

namespace DevicesManager.Server.SignalR
{
    public class DevicesHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
