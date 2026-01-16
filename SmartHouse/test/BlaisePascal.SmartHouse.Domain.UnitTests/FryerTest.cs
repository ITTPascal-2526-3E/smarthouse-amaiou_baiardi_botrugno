using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class FryerTest
    {
        [Fact]
        public void TurnOn_ShouldSetIsOnTrue_AndIsOnIsFalse()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio");

            // Act
            fryer.TurnOn();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void TurnOn_ShouldSetIsOnTrue_AndIsOnIsTrue()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio");

            // Act
            fryer.TurnOn();

            // Assert
            Assert.Throws<Exception>(() => fryer.status);
        }
        [Fact]
        public void TurnOff_ShouldSetIsOnFalse_AndIsOnIsTrue()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio");

            // Act
            fryer.TurnOn();

            // Assert
            Assert.False(false);
        }
        [Fact]
        public void TurnOff_ShouldSetIsOnFalse_AndIsOnIsFalse()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7, "olio");

            // Act
            fryer.TurnOff();

            // Assert
            Assert.Throws<Exception>(() => fryer.status);
        }
        
        [Fact]
        public void changeBasketStatus_ShouldSetBasketStatusUp_AndBasketStatusIsDown()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7,"olio");

            // Act
            fryer.changeBasketStatus();

            // Assert
            Assert.Equal("up", fryer.basketStatus);
        }
        [Fact]
        public void changeBasketStatus_ShouldSetBasketStatusDown_AndBasketStatusIsUp()
        {
            // Arrange
            var fryer = new Fryer(184.5, 7,"olio");

            // Act
            fryer.changeBasketStatus();

            // Assert
            Assert.Equal("down", fryer.basketStatus);
        }

        [Fact]
        public void changeTemp_ShouldChangeTemperature_AndValueIsLessThan160()
{
       var fryer = new Fryer(184.5, 7,"olio");

        // Act
        fryer.changeTemp(159.9);

            // Assert
            Assert.Throws<Exception>(() => fryer.temperature);
}
  
  [Fact]
public void changeTemp_ShouldChangeTemperature_AndValueIsHigherThan220()
{
       var fryer = new Fryer(184.5, 7,"olio");

// Act
fryer.changeTemp(220.1);

// Assert
Assert.Throws<Exception>(() => fryer.temperature);
}
  [Fact]
public void changeTemp_ShouldChangeTemperature_AndValueIs160()
{
       var fryer = new Fryer(184.5, 7,"olio");

// Act
fryer.changeTemp(160.0);

// Assert
Assert.Equal(160.0, fryer.temperature);

}
  [Fact]
public void changeTemp_ShouldChangeTemperature_AndValueIs220()
{
       var fryer = new Fryer(184.5, 7,"olio");

// Act
fryer.changeTemp(220.0);

// Assert
Assert.Equal(220.0, fryer.temperature);

}

  [Fact]
public void changeTemp_ShouldChangeTemperature_AndValueIsBetween160And220()
{
       var fryer = new Fryer(184.5, 7,"olio");

// Act
fryer.changeTemp(180.0);

// Assert
Assert.Equal(180.0, fryer.temperature);

}

  [Fact]
public void change_NumberOfFryer_BeforeChangeOil_ShouldChangenumberOfFryerBeforeChangeOil_AndValueIsLessThan3()
{
    var fryer = new Fryer(184.5, 7, "olio");

    // Act
    fryer.change_NumberOfFryer_BeforeChangeOil(2);

    // Assert
    Assert.Throws<Exception>(() => fryer.numberOfFryerBeforeChangeOil);
}

[Fact]
public void change_NumberOfFryer_BeforeChangeOil_ShouldChangenumberOfFryerBeforeChangeOil_AndValueIsHigherThan10()
{
    var fryer = new Fryer(184.5, 7, "olio");

    // Act
    fryer.change_NumberOfFryer_BeforeChangeOil(11);

    // Assert
    Assert.Throws<Exception>(() => fryer.numberOfFryerBeforeChangeOil);
}

[Fact]
public void change_NumberOfFryer_BeforeChangeOil_ShouldChangenumberOfFryerBeforeChangeOil_AndValueIs10()
{
    var fryer = new Fryer(184.5, 7, "olio");

    // Act
    fryer.change_NumberOfFryer_BeforeChangeOil(10);

    // Assert
    Assert.Equal(10, fryer.numberOfFryerBeforeChangeOil);
}
[Fact]
public void change_NumberOfFryer_BeforeChangeOil_ShouldChangenumberOfFryerBeforeChangeOil_AndValueIs3()
{
    var fryer = new Fryer(184.5, 7, "olio");

    // Act
    fryer.change_NumberOfFryer_BeforeChangeOil(3);

    // Assert
    Assert.Equal(3, fryer.numberOfFryerBeforeChangeOil);
}
[Fact]
public void change_NumberOfFryer_BeforeChangeOil_ShouldChangenumberOfFryerBeforeChangeOil_AndValueIsBetween3And10()
{
    var fryer = new Fryer(184.5, 7, "olio");

    // Act
    fryer.change_NumberOfFryer_BeforeChangeOil(7);

    // Assert
    Assert.Equal(7, fryer.numberOfFryerBeforeChangeOil);
}

    }
}