using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using DevicesManager.Client.Model;
using System.Diagnostics;

namespace DevicesManager.Client
{
    internal class CurrentDeviceService
    {
        public DeviceInfo GetDeviceInformation()
        {
            var machineName = Environment.MachineName;
            var machineName2 = Environment.UserName;
            var machineName3 = Environment.Is64BitOperatingSystem;
            var system = Environment.OSVersion;
            var memoryInfo = GC.GetGCMemoryInfo();
            var freeMemory = memoryInfo.TotalAvailableMemoryBytes;
            return new DeviceInfo();
        }
    }
}

//var getip = getIP();
//Console.WriteLine("Your IP Address is :" + getip);
//String hostName = Dns.GetHostName();
//Console.WriteLine("Computer name :" + hostName);

//static string getIP()
//{
//    var myhost = Dns.GetHostEntry(Dns.GetHostName());
//    foreach (var ipaddr in myhost.AddressList)
//    {
//        if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
//        {
//            return ipaddr.ToString();
//        }
//    }
//    throw new Exception("No network adapters with an IPv4 address was found");
//}
