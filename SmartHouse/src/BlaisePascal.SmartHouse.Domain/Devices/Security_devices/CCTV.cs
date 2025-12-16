using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public class CCTV
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool isOn { get; protected set; }
        private int ResolutionWidth { get; set; }
        private int resolutionHeight { get; set; }
        private int frameRate { get; set; }
        private int storageCapacity { get; set; } // in GB
        private bool nightVision_Property { get; set; }
        private bool bulletProof { get; set; }
        private const int max_storageCapacity = 500;
        private const int min_storageCapacity = 100;



        public CCTV(int ResolutionWidth, int ResolutionHeight, int frameRate, int StorageCapacity, bool nightVision, bool StartBulletProof)
        {
            Id = Guid.NewGuid();
            isOn = false;
            this.ResolutionWidth = ResolutionWidth;
            this.resolutionHeight = resolutionHeight;
            this.frameRate = frameRate;
            this.storageCapacity = storageCapacity;
            this.nightVision_Property = nightVision;
            this.bulletProof = StartBulletProof;

        }

        public int storageCapacity_Property
        {
            get { return storageCapacity; }
            set
            {
                if (storageCapacity >= min_storageCapacity && storageCapacity <= max_storageCapacity)
                {
                    storageCapacity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Storage capacity must be between {min_storageCapacity} and {max_storageCapacity} GB.");
                }
            }
        }

        public void changeStatus()
        {
            if (isOn == true)
            {
                isOn = false;
            }
            else
            {
                isOn = true;
            }
        }

        public void change_nightVision()
        {
            if (isOn == true)
            {
                if (nightVision_Property == true)
                {
                    nightVision_Property = false;
                }
                else
                {
                    nightVision_Property = true;
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot change night vision mode when CCTV is off.");

            }
        }
        public void change_bulletProof()
        {
            if (!(isOn == true))
            {
                throw new InvalidOperationException("Cannot change bullet proof mode when CCTV is on.");
            }
            else
            {
                if (bulletProof == true)
                {
                    bulletProof = false;
                }
                else
                {
                    bulletProof = true;
                }
            }
        }

        public void change_storageCapacity(int value)
        {
            if (value >= min_storageCapacity && value <= max_storageCapacity)
            { storageCapacity = value; }
            else
            {
                throw new ArgumentOutOfRangeException($"Storage capacity must be between {min_storageCapacity} and {max_storageCapacity} GB.");
            }
        }

        public void changeWidth(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Resolution width must be a positive integer.");
            }
            else
                ResolutionWidth = value;
        }

        public void changeHeight(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Resolution height must be a positive integer.");
            }
            resolutionHeight = value;
        }
    }
}