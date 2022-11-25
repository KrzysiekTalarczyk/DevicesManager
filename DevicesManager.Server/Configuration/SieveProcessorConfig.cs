using DevicesManager.Domain.Entities;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace DevicesManager.Server.Configuration
{
    public class SieveProcessorConfig : SieveProcessor
    {
        public SieveProcessorConfig(IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Device>(x => x.Id).CanFilter().CanSort();
            mapper.Property<Device>(x => x.HostName).CanFilter().CanSort();
            mapper.Property<Device>(x => x.OperationSystem).CanFilter().CanSort();
            mapper.Property<Device>(x => x.UserName).CanFilter().CanSort();
            mapper.Property<Device>(x => x.RAMAmountMB).CanFilter().CanSort();
            return mapper;
        }
    }
}
