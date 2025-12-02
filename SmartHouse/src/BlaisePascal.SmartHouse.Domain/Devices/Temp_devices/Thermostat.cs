using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Temp_devices
{
    public class Thermostat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private AirConditioner airConditioner = new AirConditioner();
        public void turnOnAirConditioner() 
        {
            airConditioner.turnOn();
            
        }
    }
}
