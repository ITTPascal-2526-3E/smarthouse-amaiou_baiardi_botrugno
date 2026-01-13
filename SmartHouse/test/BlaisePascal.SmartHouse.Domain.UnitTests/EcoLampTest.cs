using System;
using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class EcoLampTest
    {
        [Fact]
        public void turnOffAfterDuration_ShouldSetDurationBeforeOff_AndDurationIsLessThan60()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.turnOffAfterDuration(59);

            // Assert
            Assert.Throws<Exception>(() => ecolamp.DurationBeforeOff);
        }




        [Fact]
        public void turnOffAfterDuration_ShouldSetDurationBeforeOff_AndDurationIs60()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.turnOffAfterDuration(60);

            // Assert
            Assert.Equal(60, ecolamp.DurationBeforeOff);
        }
        [Fact]
        public void turnOffAfterDuration_ShouldSetDurationBeforeOff_AndDurationIsHigherThan60()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.turnOffAfterDuration(61);

            // Assert
            Assert.Equal(61, ecolamp.DurationBeforeOff);

        }

        [Fact]
        public void setEnergyClass_ShouldSetEnergyClassB_AndEnergyClassValueIsNotCorrect()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.setEnergyClass("B");

            // Assert
            Assert.Throws<Exception>(() => ecolamp.EnergyClass);

        }

        [Fact]
        public void setEnergyClass_ShouldSetEnergyClassEmpty_AndEnergyClassValueIsNotCorrect()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.setEnergyClass("");

            // Assert
            Assert.Throws<Exception>(() => ecolamp.EnergyClass);

        }


        [Fact]
        public void setEnergyClass_ShouldSetEnergyClassA_AndEnergyClassValueIsCorrect()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.setEnergyClass("A");

            // Assert
            Assert.Equal(EnergyClass.A, ecolamp.EnergyClass);

        }
        [Fact]
        public void setEnergyClass_ShouldSetEnergyClassAa_AndEnergyClassValueIsCorrect()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.setEnergyClass("Aa");

            // Assert
            Assert.Equal(EnergyClass.Aa, ecolamp.EnergyClass);

        }
        [Fact]
        public void setEnergyClass_ShouldSetEnergyClassAaa_AndEnergyClassValueIsCorrect()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.setEnergyClass("Aaa");

            // Assert
            Assert.Equal(EnergyClass.Aaa, ecolamp.EnergyClass);

        }

        [Fact]
        public void setEnergyClass_ShouldSetEnergyClassAaaa_AndEnergyClassValueIsCorrect()
        {
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88);

            // Act
            ecolamp.setEnergyClass("Aaaa");

            // Assert
            Assert.Equal(EnergyClass.Aaaa, ecolamp.EnergyClass);

        }
    }
}