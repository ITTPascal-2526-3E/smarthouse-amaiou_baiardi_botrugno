using BlaisePascal.SmartHouse.Domain.Devices; // Assumendo che 'Name' sia qui
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class CCTV_Test
    {
        // Metodo helper per creare un Name valido (aggiusta in base alla tua implementazione di Name)
        private Name GetValidName() => new Name("Camera Ingresso");

        [Fact]
        public void TurnOn_ShouldSetIsOnTrue()
        {
            // Arrange
            var cctv = new CCTV(GetValidName());

            // Act
            cctv.TurnOn();

            // Assert
            Assert.True(cctv.IsOn);
        }

        [Fact]
        public void ToggleNightVision_WhenOn_ShouldInvertProperty()
        {
            // Arrange
            var cctv = new CCTV(GetValidName());
            cctv.TurnOn();
            bool initialNightVision = cctv.NightVision;

            // Act
            cctv.ToggleNightVision();

            // Assert
            Assert.Equal(!initialNightVision, cctv.NightVision);
        }

        [Fact]
        public void ToggleNightVision_WhenOff_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var cctv = new CCTV(GetValidName());
            // Assicuriamoci che sia spenta (IsOn = false di default)

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => cctv.ToggleNightVision());
            Assert.Equal("CCTV must be on.", ex.Message);
        }

        [Fact]
        public void Arm_WhenOff_ShouldTurnOnAndArm()
        {
            // Arrange
            var cctv = new CCTV(GetValidName());

            // Act
            cctv.Arm();

            // Assert
            Assert.True(cctv.IsOn);
            Assert.True(cctv.IsArmed);
        }

        [Fact]
        public void TurnOff_ShouldSetIsOnFalse()
        {
            // Arrange
            var cctv = new CCTV(GetValidName());
            cctv.TurnOn();

            // Act
            cctv.TurnOff();

            // Assert
            Assert.False(cctv.IsOn);
        }
    }
}