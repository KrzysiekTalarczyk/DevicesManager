namespace DevicesManager.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string HostName { get; set; } = string.Empty;
        public string OperationSystem { get; set; } = string.Empty;
        public int RAMAmountMB { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string ConnectionId { get; set; } = string.Empty;
    }
}
