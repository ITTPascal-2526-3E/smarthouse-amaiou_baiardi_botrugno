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
        private AirConditioner airConditioner = new AirConditioner(18.00);
        public void turnOnAirConditioner() 
        {
            airConditioner.TurnOn();
           
        }
        public void turnOffAirConditioner()
        {
            
            airConditioner.TurnOff();
        }
        public void changeAirConditionerMode()
        {
            airConditioner.PutInEnergySavingMode();
        }
        public void changeAirConditionerFunSpeed()
        {
            airConditioner.changefunspeed();
        }
        public void increaseAirConditionerTemp()
        {
            airConditioner.increaseTemp();
        }
        public void  decreaseAirConditionerTemp()
        {
            airConditioner.decreaseTemp();

        }
        public void setName(string AirConditionerName)
        {
           airConditioner.setName(AirConditionerName);
        }

    }
}
