using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class FryerTest
    {
        private Name GetValidName() => new Name("Friggitrice Cucina");

        [Fact]
        public void TurnOn_ShouldSetStatusTrue_WhenOff()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());

            // Act
            fryer.TurnOn();

            // Assert
            Assert.True(fryer.status);
        }

        [Fact]
        public void TurnOn_ShouldThrow_WhenAlreadyOn()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());
            fryer.TurnOn();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => fryer.TurnOn());
        }

        [Fact]
        public void TurnOff_ShouldSetStatusFalse_WhenOn()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());
            fryer.TurnOn();

            // Act
            fryer.TurnOff();

            // Assert
            Assert.False(fryer.status);
        }

        [Fact]
        public void changeBasketStatus_ShouldToggleStatus()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());
            // Il default nel costruttore è "down"

            // Act 1: da down a up
            fryer.changeBasketStatus();
            Assert.Equal("up", fryer.basketStatus);

            // Act 2: da up a down
            fryer.changeBasketStatus();
            Assert.Equal("down", fryer.basketStatus);
        }

        [Fact]
        public void changeTemp_ShouldThrow_WhenValueIsOutOfRange()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => fryer.changeTemp(159.9));
            Assert.Throws<ArgumentOutOfRangeException>(() => fryer.changeTemp(220.1));
        }

        [Fact]
        public void changeTemp_ShouldUpdate_WhenValueIsInRange()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());

            // Act
            fryer.changeTemp(160.0);
            Assert.Equal(160.0, fryer.temperature);

            fryer.changeTemp(220.0);
            Assert.Equal(220.0, fryer.temperature);
        }

        [Fact]
        public void change_NumberOfFryer_ShouldThrow_WhenValueIsOutOfRange()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => fryer.change_NumberOfFryer_BeforeChangeOil(2));
            Assert.Throws<ArgumentOutOfRangeException>(() => fryer.change_NumberOfFryer_BeforeChangeOil(11));
        }

        [Fact]
        public void change_NumberOfFryer_ShouldUpdate_WhenValueIsInRange()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio", GetValidName());

            // Act
            fryer.change_NumberOfFryer_BeforeChangeOil(3);
            Assert.Equal(3, fryer.numberOfFryerBeforeChangeOil);

            fryer.change_NumberOfFryer_BeforeChangeOil(10);
            Assert.Equal(10, fryer.numberOfFryerBeforeChangeOil);
        }
    }
}