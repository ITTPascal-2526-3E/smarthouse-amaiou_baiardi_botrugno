using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories
{
    public class Alarm : SecurityDevice
    {
        public int Volume { get; private set; }
        public bool suona { get; set; }
       

        public void ChangeVolume(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException();

            Volume = value;
        }
        public void SoundAlarm()
        {
            if (!IsOn || !IsArmed)
                throw new InvalidOperationException("Alarm must be on and armed to sound.");
            else
                suona = true;
        }
    }
}
