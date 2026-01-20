using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public interface Iswitchable
    {
        public void TurnOn();

        public void TurnOff();
    }
}
