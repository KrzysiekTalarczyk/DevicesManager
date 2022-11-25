namespace DevicesManager.Client.Model
{
    internal class DeviceDto
    {
        public string HostName { get; set; }
        public string OperationSystem { get; set; }
        public int RAMAmountMB { get; set; }
        public string UserName { get; set; }
    }
}
