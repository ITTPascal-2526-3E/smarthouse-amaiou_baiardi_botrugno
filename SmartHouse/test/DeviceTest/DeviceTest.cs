using System;
using Xunit;
using BlaisePascal.SmartHouse.Domain.Devices;

namespace BlaisePascal.SmartHouse.Tests
{
    public class DeviceTests
    {
       

        [Fact]
        public void Constructor_DeviceStartsOff()
        {
            Device device = new Device();

            Assert.False(device.status);
        }

      

        [Fact]
        public void TurnOn_WhenOff_TurnsDeviceOn()
        {
            Device device = new Device();

            device.TurnOn();

            Assert.True(device.status);
        }

        [Fact]
        public void TurnOn_WhenAlreadyOn_ThrowsException()
        {
            Device device = new Device();
            device.TurnOn();

            Assert.Throws<InvalidOperationException>(() =>
            {
                device.TurnOn();
            });
        }

        

        [Fact]
        public void TurnOff_WhenOn_TurnsDeviceOff()
        {
            Device device = new Device();
            device.TurnOn();

            device.TurnOff();

            Assert.False(device.status);
        }

        [Fact]
        public void TurnOff_WhenAlreadyOff_ThrowsException()
        {
            Device device = new Device();

            Assert.Throws<InvalidOperationException>(() =>
            {
                device.TurnOff();
            });
        }
    }
}
