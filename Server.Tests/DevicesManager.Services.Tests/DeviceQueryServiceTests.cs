using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using DevicesManager.Domain.Entities;
using DevicesManager.Dtos.Requests;
using DevicesManager.Dtos.Response;
using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Exceptions;
using DevicesManager.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesManager.Services.Tests
{
    [TestClass]
    public class DeviceQueryServiceTests
    {

        [TestMethod]
        public async Task GetDevice_WhenDeviceNotFound_NotFoundExceptionIsThrown()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            repository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var service = fixture.Create<DeviceQueryService>();

            //Act
            var action = service.GetDevice(4);

            //Assert
            await Assert.ThrowsExceptionAsync<NotFoundException>(async () => await action);
        }

        [TestMethod]
        public async Task GetDevice_WhenDeviceAreFound_DeviceDtoAreReturned()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            var mapper = fixture.Freeze<Mock<IMapper>>();
            var dto = new DeviceDto() { Id = 4, OperationSystem = "XP" };

            mapper.Setup(x => x.Map<DeviceDto>(It.IsAny<Device>()))
                  .Returns(() => dto);
            var service = fixture.Create<DeviceQueryService>();

            //Act
            var result = await service.GetDevice(1);

            //Asserts
            mapper.Verify(x => x.Map<DeviceDto>(It.IsAny<Device>()), Times.Once);
            Assert.AreEqual(dto.Id, result.Id);
            Assert.AreEqual(dto.OperationSystem, result.OperationSystem);
        }


        [TestMethod]
        public async Task GetDevices_WhenDeviceAreFound_DeviceDtosAreReturned()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            var mapper = fixture.Freeze<Mock<IMapper>>();
            var devices = new List<Device>();
            var devicesDto = new List<DeviceDto>() {
                new DeviceDto() { Id = 4 },
                new DeviceDto() { Id = 5 },
                new DeviceDto() { Id = 6 }
            };
            repository.Setup(x => x.GetAll()).Returns(() => devices.AsQueryable());
            mapper.Setup(x => x.Map<IEnumerable<DeviceDto>>(It.IsAny<IEnumerable<Device>>()))
                  .Returns(() => devicesDto);

            var service = fixture.Create<DeviceQueryService>();
            var request = new GetAllDevicesRequestDto();

            //Act
            var results = await service.GetDevices(request);

            //Asserts
            mapper.Verify(x => x.Map<IEnumerable<DeviceDto>>(It.IsAny<IEnumerable<Device>>()), Times.Once);
            Assert.AreEqual(devicesDto.Count, results.Results.Count());
        }
    }
}
