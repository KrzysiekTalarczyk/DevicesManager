using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesManager.Client.Model
{
    internal class DeviceInfo
    {
        public string HostName { get; set; }
        public string OperationSystem { get; set; }

        public int RAM { get; set; }

        public string ProcessorType { get; set; }
    }
}
