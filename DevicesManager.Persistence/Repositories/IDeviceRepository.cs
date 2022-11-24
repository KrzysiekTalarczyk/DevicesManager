using DevicesManager.Domain.Entities;

namespace DevicesManager.Persistence.Repositories
{
    public interface IDeviceRepository
    {
        Task AddAsync(Device device);
        Task CompleteAsync();
        IQueryable<Device> GetAll();
        Task<Device?> GetAsync(int id);
        void Remove(Device Device);
    }
}
