using AutoMapper;
using DevicesManager.Domain.Entities;
using DevicesManager.Dtos.Response;
using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Exceptions;
using DevicesManager.Services.Interfaces;

namespace DevicesManager.Services.Services
{
    public class DeviceCommandService : IDeviceCommandService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        public DeviceCommandService(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(DeviceDto dto)
        {
            //validation
            var entity = _mapper.Map<Device>(dto);
            await _deviceRepository.AddAsync(entity);
            await _deviceRepository.CompleteAsync();
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
