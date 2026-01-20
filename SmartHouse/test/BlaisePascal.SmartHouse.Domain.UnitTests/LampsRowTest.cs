using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class LampsRowTest
    {
        [Fact]
        public void SwitchOnExasmples_True()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");
            
            row.AddLamp(lamp1);
            row.SwitchOn(lamp1.Id);

            Assert.True(lamp1.status);
        }

        public void SwitchOnExasmples_AsertError()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.SwitchOn(lamp1.Id);

            Assert.Throws<Exception>(() => row.SwitchOn(lamp1.Id));
        }

        // add other 2 methods for coverage of LampsRow class for switch off
    }
}