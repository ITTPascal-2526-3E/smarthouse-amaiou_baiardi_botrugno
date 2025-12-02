using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public class CCTV
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool isOn = false;
        private int resolutionWidth { get; set; }
        private int resolutionHeight { get; set; }
        private int frameRate { get; set; }


        private int storageCapacity;// in GB


        public int storageCapacity_Property
        {
            get { return storageCapacity; }
            set
            {
                if (storageCapacity >= min_storageCapacity && storageCapacity <= max_storageCapacity)
                {
                    storageCapacity = value;
                }
            }
        }


        private bool nightVision = true;
        private bool bulletProof = true;

        private int max_storageCapacity = 500;
        private int min_storageCapacity = 100;

        public void changeStatus()
        {
            isOn = true;
        }

        public void change_nightVision()
        {
            isOn = false;
        }
        public void change_bulletProof()
        {
            isOn = false;
        }

        public void change_storageCapacity(int value)
        {
            if (value >= min_storageCapacity && value <= max_storageCapacity)
            { storageCapacity = value; }
        }

        public void changeWidth(int value)
        {
            resolutionWidth = value;
        }

        public void changeHeight(int value)
        {
            resolutionHeight = value;
        }
    }
}
