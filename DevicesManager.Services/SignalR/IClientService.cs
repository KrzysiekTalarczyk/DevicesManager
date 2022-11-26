namespace DevicesManager.Services.SignalR
{
    public interface IClientService
    {
        Task CloseClient(string connectionId);
    }
}
