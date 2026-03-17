using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.Tests
{
    public class LampTests
    {
        // Helper per gestire l'oggetto Name richiesto dal costruttore
        private Name GetValidName(string val = "Vittorio") => new Name(val);

        [Fact]
        public void Constructor_InitializesLampCorrectly()
        {
            // Arrange & Act
            var lamp = new Lamp(40.5, 800, 10, 50, GetValidName("vitto"));

            // Assert
            Assert.False(lamp.status);
            Assert.Equal(40.5, lamp.LampHeat);
            Assert.Equal(800, lamp.Lumen);
            Assert.Equal(10, lamp.DurationBeforeItFlashes);
            Assert.Equal(50, lamp.brightness);
            Assert.Equal("vitto", lamp.Name);
        }

        [Fact]
        public void SetLampType_WithInvalidType_ThrowsArgumentException()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => lamp.setLampType("InvalidType"));
        }

        [Fact]
        public void SetEnergyClass_WithValidClass_SetsEnergyClass()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());

            // Act
            lamp.setEnergyClass("A");

            // Assert
            Assert.Equal(EnergyClass.A, lamp.EnergyClass);
        }

        [Fact]
        public void ChangeColor_WhenLampIsLed_ChangesColor()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());
            lamp.setLampType("led"); // Importante: deve essere LED per cambiare colore

            // Act
            lamp.changeColor("red"); // Uso "red" minuscolo se l'enum segue lo standard C# o quello che hai definito

            // Assert
            Assert.Equal(Color.red, lamp.color);
        }

        [Fact]
        public void ChangeColor_WhenLampIsNotLed_ThrowsInvalidOperationException()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());
            // Il default non è LED (assumendo halogen o neon)
            lamp.setLampType("halogen");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => lamp.changeColor("red"));
        }

        [Fact]
        public void SetBrightness_TooLow_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.setBrightness(-1));
        }

        [Fact]
        public void SetBrightness_TooHigh_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.setBrightness(101));
        }

        [Fact]
        public void TurnOn_WhenOff_SetsStatusTrue()
        {
            // Arrange
            var lamp = new Lamp(40, 600, 5, 30, GetValidName());

            // Act
            lamp.TurnOn();

            // Assert
            Assert.True(lamp.status);
        }
    }
}