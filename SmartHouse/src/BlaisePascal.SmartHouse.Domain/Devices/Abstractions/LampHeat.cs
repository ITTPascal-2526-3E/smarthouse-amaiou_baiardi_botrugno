using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class LampHeat
    {
        public int value { get; private set; }

        public LampHeat(int lampHeat)
        {
            if (lampHeat == null)
            {
                throw new ArgumentOutOfRangeException(nameof(lampHeat), "Lamp heat must be inserted");
            }
            else if (lampHeat < 30 || lampHeat > 900)
            {
                throw new ArgumentOutOfRangeException(nameof(lampHeat), "Lamp heat must be between 30 and 900");
            }
            else
            {
                value = lampHeat;
            }
               
        }
    }
}
