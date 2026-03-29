using System;
using Xunit;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;

namespace BlaisePascal.SmartHouse.Tests
{
    public class AirConditionerTests
    {

        [Fact]
        public void PutInEnergySavingMode_EnablesMode()
        {
            AirConditioner ac = new AirConditioner(20);

            ac.PutInEnergySavingMode();

            Assert.True(ac.energySavingMode);
        }

        [Fact]
        public void PutInEnergySavingMode_AlreadyEnabled_ThrowsException()
        {
            AirConditioner ac = new AirConditioner(20);
            ac.PutInEnergySavingMode();

            Assert.Throws<InvalidOperationException>(() =>
            {
                ac.PutInEnergySavingMode();
            });
        }


        [Fact]
        public void IncreaseTemp_WhenOn_IncreasesTemperature()
        {
            AirConditioner ac = new AirConditioner(20);
            ac.status = true;

            ac.increaseTemp();

            Assert.Equal(21, ac.temp);
        }

        [Fact]
        public void IncreaseTemp_WhenOff_ThrowsException()
        {
            AirConditioner ac = new AirConditioner(20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                ac.increaseTemp();
            });
        }

        [Fact]
        public void DecreaseTemp_WhenOn_DecreasesTemperature()
        {
            AirConditioner ac = new AirConditioner(20);
            ac.status = true;

            ac.decreaseTemp();

            Assert.Equal(19, ac.temp);
        }

        [Fact]
        public void DecreaseTemp_WhenOff_ThrowsException()
        {
            AirConditioner ac = new AirConditioner(20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                ac.decreaseTemp();
            });
        }

        [Fact]
        public void SetName_ValidName_DoesNotThrow()
        {
            AirConditioner ac = new AirConditioner(20);

            ac.setName("Bedroom AC");
        }

        [Fact]
        public void SetName_EmptyName_ThrowsException()
        {
            AirConditioner ac = new AirConditioner(20);

            Assert.Throws<ArgumentException>(() =>
            {
                ac.setName("");
            });
        }

        [Fact]
        public void SetName_NullName_ThrowsException()
        {
            AirConditioner ac = new AirConditioner(20);

            Assert.Throws<ArgumentException>(() =>
            {
                ac.setName(null);
            });
        }

        [Fact]
        public void ChangeFanSpeed_WhenOff_ThrowsException()
        {
            AirConditioner ac = new AirConditioner(20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                ac.changefunspeed();
            });
        }
    }
}
