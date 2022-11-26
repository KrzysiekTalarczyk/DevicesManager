using AutoFixture;
using AutoFixture.AutoMoq;
using DevicesManager.Dtos.Response;
using DevicesManager.Services.Interfaces;
using DevicesManager.Services.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace DevicesManager.Services.Tests
{
    [TestClass]
    public class DevicesHubTests
    {
       [TestMethod]
        public async Task SendDeviceInfo_NewDevice_AreAdded()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var deviceCommandService = fixture.Freeze<Mock<IDeviceCommandService>>();
            var dto = new DeviceDto { ConnectionId = "connectionId" };
            var hub = fixture.Create<DevicesHub>();

            //Act
            await hub.SendDeviceInfo(dto);

            //Assert
            deviceCommandService.Verify(x => x.AddAsync(It.IsAny<DeviceDto>()), Times.Once);
        }
    }
}
