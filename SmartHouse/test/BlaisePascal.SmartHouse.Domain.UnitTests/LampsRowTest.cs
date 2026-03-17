using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class LampsRowTest
    {
        // Helper per creare un oggetto Name valido
        private Name GetName(string value) => new Name(value);

        [Fact]
        public void SwitchOn_ShouldTurnOnSpecificLamp()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));
            row.AddLamp(lamp1);

            // Act
            row.SwitchOn(lamp1.Id);

            // Assert
            Assert.True(lamp1.status);
        }

        [Fact] // Mancava l'attributo Fact
        public void SwitchOn_ShouldThrow_WhenLampIsAlreadyOn()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));
            row.AddLamp(lamp1);
            row.SwitchOn(lamp1.Id); // La accendo la prima volta

            // Act & Assert
            // Nota: L'eccezione viene lanciata da lamp1.TurnOn() chiamato dentro row.SwitchOn
            Assert.Throws<InvalidOperationException>(() => row.SwitchOn(lamp1.Id));
        }

        [Fact]
        public void SwitchOff_ShouldTurnOffSpecificLamp()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));
            row.AddLamp(lamp1);
            row.SwitchOn(lamp1.Id); // Prima accendo

            // Act
            row.SwitchOff(lamp1.Id);

            // Assert
            Assert.False(lamp1.status);
        }

        [Fact]
        public void SetIntensityForLamp_ShouldUpdateBrightness_WhenValueIsValid()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));
            row.AddLamp(lamp1);

            // Act
            row.SetIntensityForLamp(lamp1.Id, 77);

            // Assert
            Assert.Equal(77, lamp1.brightness);
        }

        [Fact] // Mancava Fact
        public void SetIntensityForLamp_ShouldThrow_WhenIntensityIsNegative()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));
            row.AddLamp(lamp1);

            // Act & Assert
            // Assumendo che setBrightness lanci ArgumentOutOfRangeException per valori negativi
            Assert.Throws<ArgumentOutOfRangeException>(() => row.SetIntensityForLamp(lamp1.Id, -1));
        }

        [Fact]
        public void changeColor_ShouldUpdateColor_WhenValueIsCorrect()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));
            row.AddLamp(lamp1);

            // Act
            row.changeColor(lamp1.Id, "pink");

            // Assert
            Assert.Equal(Color.pink, lamp1.color);
        }

        [Fact]
        public void AddLampInPosition_ShouldThrow_WhenPositionIsInvalid()
        {
            // Arrange
            var row = new LampsRow();
            var lamp1 = new Lamp(10.0, 800, 1000, 50, GetName("Lamp1"));

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => row.AddLampInPosition(lamp1, 99));
        }
    }
}