using AutoMapper;
using DevicesManager.Dtos.Requests;
using DevicesManager.Dtos.Response;
using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Exceptions;
using DevicesManager.Services.Interfaces;

namespace DevicesManager.Services.Services
{
    public class DeviceQueryService : IDeviceQueryService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IQueryFrameExecutor _queryFrameExecutor;
        private readonly IMapper _mapper;
        public DeviceQueryService(IDeviceRepository deviceRepository,
                                   IQueryFrameExecutor queryFrameExecutor,
                                   IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _queryFrameExecutor = queryFrameExecutor;
            _mapper = mapper;
        }

        public async Task<DeviceDto> GetDevice(int id)
        {
            var device = await _deviceRepository.GetAsync(id);
            if (device is null)
               throw new NotFoundException($"The Device with id {id} not found");
            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<FilteredResponse<DeviceDto>> GetDevices(GetAllDevicesRequestDto request)
        {
            var devices = _deviceRepository.GetAll();
            var filteredResults = await _queryFrameExecutor.SelectData(devices, request);
            var devicesDto = _mapper.Map<IEnumerable<DeviceDto>>(filteredResults.Results);
            return new FilteredResponse<DeviceDto>(devicesDto, filteredResults.TotalResultCount);
        }
    }
}
