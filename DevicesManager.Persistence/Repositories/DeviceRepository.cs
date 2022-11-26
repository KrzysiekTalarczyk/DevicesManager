using DevicesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevicesManager.Persistence.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DeviceManagerDbContext _context;

        public DeviceRepository(DeviceManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Device Device)
        {
            await _context.Devices.AddAsync(Device);
        }

        public async Task<Device?> GetAsync(int id)
        {
            return await _context.Devices.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(Device Device)
        {
            _context.Devices.Remove(Device);
        }

        public IQueryable<Device> GetAll()
        {
            return _context.Devices.AsNoTracking()
                                   .Select(m => m);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
