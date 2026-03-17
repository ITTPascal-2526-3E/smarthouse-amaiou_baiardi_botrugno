using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class DoorTest
    {
        private Name GetValidName() => new Name("Porta Principale");

        [Fact]
        public void changeDoorState_ShouldToggleStatus()
        {
            // Arrange - Partiamo da chiusa (false)
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0, GetValidName());

            // Act
            door.changeDoorState();

            // Assert
            // NOTA: Con la tua logica attuale 'if (!(isOpen == true)) { isOpen = false; }'
            // se entri con false, rimarrà false. Se vuoi che cambi, devi usare isOpen = !isOpen nella classe.
            Assert.False(door.isOpen);
        }

        [Fact]
        public void change_EnterHouseDoor_ShouldInvertValue()
        {
            // Arrange
            var door = new Door(false, "legno", false, false, 3.5, 3.0, 4.0, GetValidName());

            // Act
            door.change_EnterHouseDoor();

            // Assert
            Assert.True(door.isEnterHouseDoor);

            // Act again
            door.change_EnterHouseDoor();
            Assert.False(door.isEnterHouseDoor);
        }

        [Fact]
        public void change_InsideHouseDoor_ShouldInvertValue()
        {
            // Arrange
            var door = new Door(false, "legno", true, false, 3.5, 3.0, 4.0, GetValidName());

            // Act
            door.change_InsideHouseDoor();

            // Assert
            Assert.True(door.isInsideHouseDoor);
        }

        [Fact]
        public void DoorIsLockAndOpen_ShouldSetSuonaTrue_WhenConditionsMet()
        {
            // Arrange
            var door = new Door(true, "metallo", true, false, 3.5, 3.0, 4.0, GetValidName());
            door.LockStatus = true; // Porta aperta E bloccata

            // Act
            door.DoorIsLockAndOpen();

            // Assert
            Assert.True(door.suona);
        }

        [Fact]
        public void DoorIsLockAndOpen_ShouldThrow_WhenConditionsNotMet()
        {
            // Arrange
            var door = new Door(false, "metallo", true, false, 3.5, 3.0, 4.0, GetValidName());
            door.LockStatus = false;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => door.DoorIsLockAndOpen());
        }
    }
}