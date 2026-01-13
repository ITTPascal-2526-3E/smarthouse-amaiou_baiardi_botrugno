using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public abstract class Device 
    {
       
        public bool status { get; protected set; }
      
        public Device() 
        { 
            status = false;
        }
        public abstract void TurnOn();

        public abstract void TurnOff();
    }
}
