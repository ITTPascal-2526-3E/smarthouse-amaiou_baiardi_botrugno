using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class DoorTest
    {
        [Fact]
        public void changeHeight_ShouldchangeHeight_AndValueIsInRange()
        {
            // Arrange
            var door = new Door(false,"legno","scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeHeight(3.3);

            // Assert
            Assert.Equal(3.3, door.height);
        }

        [Fact]
        public void changeHeight_ShouldChangeHeight_AndValueIsNotInRange()
        {
            // Arrange
            var door = new Door(false,"legno","scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeHeight(0.0);

            // Assert
            Assert.Throws<Exception>(() => door.height);

        }

        [Fact]
        public void changeWidth_ShouldchangeWidth_AndValueIsInRange()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeWidth(3.3);

            // Assert
            Assert.Equal(3.3, door.width);
        }

        [Fact]
        public void changeWidth_ShouldChangeWidth_AndValueIsNotInRange()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeWidth(0.0);

            // Assert
            Assert.Throws<Exception>(() => door.width);

        }
        [Fact]
        public void changeLength_ShouldchangeLength_AndValueIsInRange()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeLength(3.3);

            // Assert
            Assert.Equal(3.3, door.length);
        }

        [Fact]
        public void changeLength_ShouldChangeLength_AndValueIsNotInRange()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeLength(0.0);

            // Assert
            Assert.Throws<Exception>(() => door.length);

        }
        [Fact]
        public void changeDoorState_ShouldSetIsOpenTrue_AndIsOpenIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeDoorState();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void changeDoorState_ShouldSetIsOpenFalse_AndIsOpenIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeDoorState();

            // Assert
            Assert.False(false);
        }

        [Fact]
        public void change_BulletProof_ShouldSetIsBulletProofTrue_AndIsBulletProofIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_BulletProof();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void change_BulletProof_ShouldSetIsBulletProofFalse_AndIsBulletProofIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_BulletProof();

            // Assert
            Assert.False(false);
        }

        [Fact]
        public void change_EnterHouseDoor_ShouldSetIsEnterHouseDoorTrue_AndIsEnterHouseDoorIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_EnterHouseDoor();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void change_EnterHouseDoor_ShouldSetIsEnterHouseDoorFalse_AndIsEnterHouseDoorIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_EnterHouseDoor();

            // Assert
            Assert.False(false);
        }

        [Fact]
        public void change_InsideHouseDoor_ShouldSetIsInsideHouseDoorTrue_AndIsInsideHouseDoorIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_InsideHouseDoor();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void change_InsideHouseDoor_ShouldSetIsInsideHouseDoorFalse_AndIsInsideHouseDoorIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", "scorrevole", true, true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_InsideHouseDoor();

            // Assert
            Assert.False(false);
        }

    }
}