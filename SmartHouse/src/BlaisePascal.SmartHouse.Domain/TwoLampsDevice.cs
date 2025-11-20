using BlaisePascal.SmartHouse.LampType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampsDevice
    {
        private Lamp lamp = new Lamp();
        private EcoLamp ecoLamp = new EcoLamp();
        public void getLampAttribute(Enum lampType, double lampHeat, Enum energyClass)
        {
            

        }
    }
}
