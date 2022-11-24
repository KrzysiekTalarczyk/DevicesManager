namespace DevicesManager.Dtos.Response
{
    public class DeviceDto
    {
        public string HostName { get; set; }
        public string OperationSystem { get; set; }

        public int RAM { get; set; }

        public string ProcessorType { get; set; }
    }
}
