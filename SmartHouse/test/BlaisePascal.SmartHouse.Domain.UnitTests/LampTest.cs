using System;
using Xunit;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;

namespace BlaisePascal.SmartHouse.Tests
{
    public class LampTests
    {
        

        [Fact]
        public void Constructor_InitializesLampCorrectly()
        {
            Lamp lamp = new Lamp(40.5, 800, 10, 50, "vitto");

            Assert.False(lamp.status);
            Assert.Equal(40.5, lamp.LampHeat);
            Assert.Equal(800, lamp.Lumen);
            Assert.Equal(10, lamp.DurationBeforeItFlashes);
            Assert.Equal(50, lamp.brightness);
        }

       


        [Fact]
        public void SetLampType_WithInvalidType_ThrowsException()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30,"vitto");

            Assert.Throws<ArgumentException>(() =>
            {
                lamp.setLampType("InvalidType");
            });
        }

       

        [Fact]
        public void SetEnergyClass_WithValidClass_SetsEnergyClass()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");

            lamp.setEnergyClass("A");

            Assert.Equal(EnergyClass.A, lamp.EnergyClass);
        }

        [Fact]
        public void SetEnergyClass_WithInvalidClass_ThrowsException()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");

            Assert.Throws<ArgumentException>(() =>
            {
                lamp.setEnergyClass("Z");
            });
        }

        

        [Fact]
        public void ChangeColor_WhenLampIsLed_ChangesColor()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");
            lamp.setLampType("led");

            lamp.changeColor("Red");

            Assert.Equal(Color.red, lamp.color);
        }

        [Fact]
        public void ChangeColor_WhenLampIsNotLed_ThrowsException()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");
            lamp.setLampType("halogen");

            Assert.Throws<InvalidOperationException>(() =>
            {
                lamp.changeColor("Blue");
            });
        }

       
        [Fact]
        public void SetBrightness_WithValidValue_SetsBrightness()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");

            lamp.setBrightness(80);

            Assert.Equal(80, lamp.brightness);
        }

        [Fact]
        public void SetBrightness_TooLow_ThrowsException()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                lamp.setBrightness(-1);
            });
        }

        [Fact]
        public void SetBrightness_TooHigh_ThrowsException()
        {
            Lamp lamp = new Lamp(40, 600, 5, 30, "vitto");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                lamp.setBrightness(101);
            });
        }
    }
}
