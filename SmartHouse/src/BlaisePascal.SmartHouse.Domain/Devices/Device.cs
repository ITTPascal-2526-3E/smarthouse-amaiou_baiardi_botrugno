using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public interface Device 
    {
        public abstract void TurnOn();

        public abstract void TurnOff();
    }
}
