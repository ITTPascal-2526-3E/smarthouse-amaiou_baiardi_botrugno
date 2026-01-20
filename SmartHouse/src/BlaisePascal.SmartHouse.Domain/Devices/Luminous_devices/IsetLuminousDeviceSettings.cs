using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public interface IsetLuminousDeviceSettings
    {
        public void setEnergyClass(string energyClassValue);
        public LampType setLampType(string lampTypeValue);
        public void setBrightness(int newBrightness);
        public void changeColor(string newColor);

    }
}
