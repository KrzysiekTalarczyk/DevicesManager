namespace DevicesManager.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string OperationSystem { get; set; }

        public int RAM { get; set; }

        public string ProcessorType { get; set; }
        //    host name, operating system and some
        //additional information – e.g.RAM, processor etc.)
    }
}
