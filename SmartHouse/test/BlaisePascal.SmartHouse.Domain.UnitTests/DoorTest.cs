using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class DoorTest
    {
        [Fact]
        public void changeDoorState_ShouldSetIsOpenTrue_AndIsOpenIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeDoorState();

            // Assert
            Assert.True(door.isOpen);
        }
        [Fact]
        public void changeDoorState_ShouldSetIsOpenFalse_AndIsOpenIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0);

            // Act
            door.changeDoorState();

            // Assert
            Assert.False(door.isOpen);
        }
        [Fact]
        public void change_EnterHouseDoor_ShouldSetIsEnterHouseDoorTrue_AndIsEnterHouseDoorIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_EnterHouseDoor();

            // Assert
            Assert.True(door.isEnterHouseDoor);
        }
        [Fact]
        public void change_EnterHouseDoor_ShouldSetIsEnterHouseDoorFalse_AndIsEnterHouseDoorIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_EnterHouseDoor();

            // Assert
            Assert.False(door.isEnterHouseDoor);
        }

        [Fact]
        public void change_InsideHouseDoor_ShouldSetIsInsideHouseDoorTrue_AndIsInsideHouseDoorIsFalse()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_InsideHouseDoor();

            // Assert
            Assert.True(door.isInsideHouseDoor);
        }
        [Fact]
        public void change_InsideHouseDoor_ShouldSetIsInsideHouseDoorFalse_AndIsInsideHouseDoorIsTrue()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0);

            // Act
            door.change_InsideHouseDoor();

            // Assert
            Assert.False(door.isInsideHouseDoor);
        }

    }
}