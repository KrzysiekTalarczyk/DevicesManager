using DevicesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevicesManager.Persistence
{
    public class DeviceManagerDbContext : DbContext
    {
        public DeviceManagerDbContext(DbContextOptions<DeviceManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Device> Devices => Set<Device>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasKey(x => x.Id);
        }
    }
}