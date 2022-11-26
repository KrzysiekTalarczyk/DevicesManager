using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using DevicesManager.Domain.Entities;
using DevicesManager.Dtos.Response;
using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Exceptions;
using DevicesManager.Services.Services;
using DevicesManager.Services.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace DevicesManager.Services.Tests
{
    [TestClass]
    public class DeviceCommandServiceTests
    {
        [TestMethod]
        public async Task AddAsync_ForGivenDto_NewDevicesAreAdded()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            var mapper = fixture.Freeze<Mock<IMapper>>();
            var dto = new DeviceDto() { Id = 4, OperationSystem = "XP" };
            mapper.Setup(x => x.Map<Device>(It.IsAny<DeviceDto>()))
                  .Returns(() => new Device());

            var service = fixture.Create<DeviceCommandService>();
            await service.AddAsync(dto);

            mapper.Verify(x => x.Map<Device>(It.IsAny<DeviceDto>()), Times.Once);
            repository.Verify(x => x.AddAsync(It.IsAny<Device>()), Times.Once);
            repository.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [TestMethod]
        public async Task DeleteDevice_WhenDeviceIsFound_DevicesAreRemoved()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            var device = new Device() { Id = 4, OperationSystem = "XP" };
            repository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(device);
            var service = fixture.Create<DeviceCommandService>();

            //Act
            await service.DeleteDevice(device.Id);

            //Assert
            repository.Verify(x => x.Remove(It.IsAny<Device>()), Times.Once);
            repository.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [TestMethod]
        public async Task DeleteDevice_WhenDeviceNotFound_NotFoundExceptionIsThrown()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            repository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var service = fixture.Create<DeviceCommandService>();

            //Act
            var action = service.DeleteDevice(4);

            //Assert
            await Assert.ThrowsExceptionAsync<NotFoundException>(async () => await action);
        }

        [TestMethod]
        public async Task DeleteDevice_WhenDeviceWasRemoved_ClientAreClosed()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var clientService = fixture.Freeze<Mock<IClientService>>();
            var repository = fixture.Freeze<Mock<IDeviceRepository>>();
            var device = new Device() { Id = 4, OperationSystem = "XP" };
            repository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(device);
            var service = fixture.Create<DeviceCommandService>();
            
            //Act
            await service.DeleteDevice(device.Id);

            //Assert
            clientService.Verify(x => x.CloseClient(It.IsAny<string>()), Times.Once);
        }
    }
}
