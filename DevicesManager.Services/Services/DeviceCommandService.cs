using AutoMapper;
using DevicesManager.Domain.Entities;
using DevicesManager.Dtos.Response;
using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Exceptions;
using DevicesManager.Services.Interfaces;
using DevicesManager.Services.SignalR;

namespace DevicesManager.Services.Services
{
    public class DeviceCommandService : IDeviceCommandService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private IClientService _clientService;
        public DeviceCommandService(IDeviceRepository deviceRepository,
                                    IMapper mapper,
                                    IClientService clientService)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _clientService = clientService;
        }

        public async Task AddAsync(DeviceDto dto)
        {
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
            await _clientService.CloseClient(device.ConnectionId);
        }
    }
}
