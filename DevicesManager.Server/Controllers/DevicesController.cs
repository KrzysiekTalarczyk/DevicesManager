using DevicesManager.Dtos.Requests;
using DevicesManager.Dtos.Response;
using DevicesManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace DevicesManager.Server.Controllers
{

    [Route("api/[controller]")]
    public class DevicesController : BaseController
    {
        private readonly IDeviceQueryService _devicesQueryService;
        private readonly IDeviceCommandService _devicesCommandService;
        public DevicesController(IDeviceQueryService devicesQueryService, IDeviceCommandService devicesCommandService)
        {
            _devicesQueryService = devicesQueryService;
            _devicesCommandService = devicesCommandService;
        }


        /// <summary>
        /// Get all devices.
        /// </summary>
        /// <param name="query"> filtering, sorting, pagination etc.</param>
        /// <returns>Collection of deviceDto objects</returns>
        [HttpGet]
        [OpenApiOperation("Get all devices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DeviceDto>>> GetAll([FromQuery] GetAllDevicesRequestDto query)
        {
            var response = await _devicesQueryService.GetDevices(query);
            return Ok(response.Results, query, response.TotalResultCount);
        }

        /// <summary>
        /// Get one device information.
        /// </summary>
        /// <param name="id">id of device</param>
        /// <returns>DeviceDto</returns>
        /// <response code="200">OK with deviceDto object</response>
        /// <response code="404">When device not found</response>
        /// <response code="500">Any exception</response>
        [HttpGet("{id}")]
        [OpenApiOperation("Get device")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeviceDto>> Get(int id)
        {
            var result = await _devicesQueryService.GetDevice(id);
            return Ok(result);
        }

        /// <summary>
        /// Delete device
        /// </summary>
        /// <param name="id">Id of device for deleting</param>
        /// <response code="200">OK when device deleted with success</response>
        /// <response code="404">When device not found</response>
        /// <response code="500">Any exception</response>
        [HttpDelete("{id}")]
        [OpenApiOperation("Delete device")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _devicesCommandService.DeleteDevice(id);
            return Ok();
        }
    }
}
