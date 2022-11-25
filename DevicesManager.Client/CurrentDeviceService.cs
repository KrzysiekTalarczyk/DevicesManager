using DevicesManager.Client.Model;

namespace DevicesManager.Client
{
    internal class CurrentDeviceService : ICurrentDeviceService
    {
        public DeviceDto GetDeviceInformation()
        {
            try
            {
                var machineName = Environment.MachineName;
                var user = Environment.UserName;
                var system = Environment.OSVersion.VersionString;
                var memory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
                var memoryMB = memory / 1024 / 1024;
                return new DeviceDto
                {
                    HostName = machineName,
                    UserName = user,
                    OperationSystem = system,
                    RAMAmountMB = (int)memoryMB
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some errors occure when collecting cilent information {ex.Message}");
                throw;
            }

        }
    }
}
