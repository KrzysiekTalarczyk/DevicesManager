using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Exceptions;
using DevicesManager.Services.Interfaces;

namespace DevicesManager.Services.Services
{
    public class DeviceCommandService : IDeviceCommandService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceCommandService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task DeleteDevice(int id)
        {
            var device = await _deviceRepository.GetAsync(id);
            if (device == null)
                throw new NotFoundException($"Entity with Id {id} not found");
            _deviceRepository.Remove(device);
            await _deviceRepository.CompleteAsync();
            //hub
        }
    }
}
