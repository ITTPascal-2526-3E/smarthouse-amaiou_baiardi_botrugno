using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class EcoLampTest
    {
        // Helper per il nome
        private Name GetValidName() => new Name("Lampada Eco Soggiorno");

        [Fact]
        public void turnOffAfterDuration_ShouldThrowException_WhenDurationIsLessThan60()
        {
            // Arrange
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88, GetValidName());

            // Act & Assert
            // L'eccezione viene lanciata dal METODO, non dalla proprietà
            Assert.Throws<ArgumentOutOfRangeException>(() => ecolamp.turnOffAfterDuration(59));
        }

        [Fact]
        public void turnOffAfterDuration_ShouldSetDuration_WhenDurationIs60()
        {
            // Arrange
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88, GetValidName());

            // Act
            ecolamp.turnOffAfterDuration(60);

            // Assert
            Assert.Equal(60, ecolamp.DurationBeforeOff);
        }

        [Fact]
        public void setEnergyClass_ShouldThrowException_WhenClassIsInvalid()
        {
            // Arrange
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88, GetValidName());

            // Act & Assert
            // Verifichiamo che lanci ArgumentException se passiamo "B"
            Assert.Throws<ArgumentException>(() => ecolamp.setEnergyClass("B"));
        }

        [Fact]
        public void setEnergyClass_ShouldSetCorrectClass_WhenValueIsA()
        {
            // Arrange
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88, GetValidName());

            // Act
            ecolamp.setEnergyClass("A");

            // Assert
            Assert.Equal(EnergyClass.A, ecolamp.EnergyClass);
        }

        [Fact]
        public void setEnergyClass_ShouldSetCorrectClass_WhenValueIsAaaa()
        {
            // Arrange
            var ecolamp = new EcoLamp(100.5, 9000, 20000, 88, GetValidName());

            // Act
            ecolamp.setEnergyClass("Aaaa");

            // Assert
            Assert.Equal(EnergyClass.Aaaa, ecolamp.EnergyClass);
        }
    }
}