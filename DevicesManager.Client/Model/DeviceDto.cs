namespace DevicesManager.Client.Model
{
    public class DeviceDto
    {
        public string HostName { get; set; } = string.Empty;
        public string OperationSystem { get; set; } = string.Empty;
        public int RAMAmountMB { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{nameof(HostName)}: {HostName}{Environment.NewLine}" +
                   $"{nameof(OperationSystem)}: {OperationSystem}{Environment.NewLine}" +
                   $"{nameof(RAMAmountMB)}: {RAMAmountMB}{Environment.NewLine}" +
                   $"{nameof(UserName)}: {UserName}{Environment.NewLine}";
        }
    }

}
