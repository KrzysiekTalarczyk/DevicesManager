using DevicesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevicesManager.Persistence
{
    public class DeviceManagerDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DeviceManagerDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DeviceDatabase"));
        }

        public DbSet<Device> Devices { get; set; }
     
    }
}