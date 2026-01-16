using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class CCTV_Test
    {
        [Fact]
        public void TurnOn_ShouldSetIsOnTrue_AndIsOnIsFalse()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.TurnOn();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void TurnOff_ShouldSetIsOnFalse_AndIsOnIsTrue()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.TurnOn();

            // Assert
            Assert.False(false);
        }
        [Fact]
        public void TurnOff_ShouldSetIsOnFalse_AndIsOnIsFalse()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true, true);

            // Act
            cctv.TurnOn();

            // Assert
            Assert.Throws<Exception>(() => cctv.isOn);
        }
        [Fact]
        public void TurnOn_ShouldSetIsOnTrue_AndIsOnIsTrue()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true, true);

            // Act
            cctv.TurnOn();

            // Assert
            Assert.Throws<Exception>(() => cctv.isOn);
        }
        [Fact]
        public void change_nightVision_ShouldSetnightVision_PropertyTrue_AndIsOnIsTrueAndNightVision_PropertyIsFalse()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_nightVision();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void change_nightVision_ShouldSetnightVision_PropertyFalse_AndIsOnIsTrueAndNightVision_PropertyIsTrue()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_nightVision();

            // Assert
            Assert.False(false);
        }

        [Fact]
        public void change_nightVision_ShouldSetnightVision_PropertyFalse_AndIsOnIsFalse()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_nightVision();

        // Assert
       Assert.Throws<Exception>(() => cctv.isOn);

        }
        [Fact]
        public void change_bulletProof_ShouldSetBulletProofTrue_AndIsOnIsTrueAndBulletProofIsFalse()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_bulletProof();

            // Assert
            Assert.True(true);
        }
        [Fact]
        public void change_bulletProof_ShouldSetBulletProofFalse_AndIsOnIsTrueAndBulletProofIsTrue()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_bulletProof();

            // Assert
            Assert.False(false);
        }

        [Fact]
        public void change_bulletProof_ShouldSetBulletProofFalse_AndIsOnIsFalse()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_nightVision();

        // Assert
       Assert.Throws<Exception>(() => cctv.isOn);

        }
        [Fact]
        public void change_storageCapacity_ShouldChange_storageCapacity300_AndValueIsInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_storageCapacity(300);

            // Assert
            Assert.Equal(300, cctv.storageCapacity);
        }

        [Fact]
        public void change_storageCapacity_ShouldChange_storageCapacity99_AndValueIsNotInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.change_storageCapacity(99);

        // Assert
       Assert.Throws<Exception>(() => cctv.storageCapacity);

        }
        [Fact]
        public void change_storageCapacity_ShouldChange_storageCapacity501_AndValueIsNotInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true, true);

            // Act
            cctv.change_storageCapacity(501);

            // Assert
            Assert.Throws<Exception>(() => cctv.storageCapacity);

        }

        [Fact]
        public void changeWidth_ShouldchangeResolutionWidth20_AndValueIsInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.changeWidth(20);

            // Assert
            Assert.Equal(20, cctv.ResolutionWidth);
        }

        [Fact]
        public void changeWidth_ShouldChangeResolutionWidth0_AndValueIsNotInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.changeWidth(0);

        // Assert
       Assert.Throws<Exception>(() => cctv.ResolutionWidth);

        }

        [Fact]
        public void changeHeight_ShouldchangeResolutionHeight33_AndValueIsInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.changeHeight(33);

            // Assert
            Assert.Equal(33, cctv.resolutionHeight);
        }

        [Fact]
        public void changeHeight_ShouldChangeResolutionHeight0_AndValueIsNotInRange()
        {
            // Arrange
            var cctv = new CCTV(40, 30, 100, 300, true,true);

            // Act
            cctv.changeHeight(0);

        // Assert
       Assert.Throws<Exception>(() => cctv.resolutionHeight);

        }
    }
}