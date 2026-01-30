using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class LampsRowTest
    {
        [Fact]
        public void SwitchOn_ShouldSetStatusTrue_AndStatusIsFalse()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");
            
            row.AddLamp(lamp1);
            row.SwitchOn(lamp1.Id);

            Assert.True(lamp1.status);
        }

        public void SwitchOn_ShouldSetStatusTrue_AndStatusIsTrue()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.SwitchOn(lamp1.Id);

            Assert.Throws<Exception>(() => row.SwitchOn(lamp1.Id));
        }
        [Fact]
        public void SwitchOff_ShouldSetStatusFalse_AndStatusIsTrue()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.SwitchOff(lamp1.Id);

            Assert.False(lamp1.status);
        }

        public void SwitchOff_ShouldSetStatusFalse_AndStatusIsFalse()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.SwitchOff(lamp1.Id);

            Assert.Throws<Exception>(() => row.SwitchOff(lamp1.Id));
        }
        [Fact]
        public void SetIntensityForLamp_ShouldSetIntensity_AndIntensityValueIsCorrect()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.SetIntensityForLamp(lamp1.Id,77);

            Assert.Equal(lamp1.brightness,77);
        }

        public void SetIntensityForLamp_ShouldSetIntensity_AndIntensityValueIsNotCorrect()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.SetIntensityForLamp(lamp1.Id,-1);

            Assert.Throws<Exception>(() => row.SetIntensityForLamp(lamp1.Id,-1));
        }
        [Fact]
        public void changeColor_ShouldSetColor_AndColorValueIsCorrect()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.changeColor(lamp1.Id, "pink");

            Assert.Equal(lamp1.Color, "pink");
        }

        public void changeColor_ShouldSetColor_AndColorValueIsNotCorrect()
        {
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, "Lamp1");

            row.AddLamp(lamp1);
            row.changeColor(lamp1.Id,"");

            Assert.Throws<Exception>(() => row.changeColor(lamp1.Id,""));
        }
    }
}