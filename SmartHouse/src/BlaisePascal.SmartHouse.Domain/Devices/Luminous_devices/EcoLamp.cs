using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public class EcoLamp : Lamp
    {
        //Creazione variabili/attributi
        public int DurationBeforeOff { get; private set; }
        //Costruttore di EcoLamp
        public EcoLamp(double lampHeat, int lumen, int durationBeforeItFlashes) 
            : base(lampHeat, lumen, durationBeforeItFlashes)
        {
            Id = Guid.NewGuid();
            IsOn = false;
            this.Lumen = lumen;
            this.LampHeat = lampHeat;
        }





        //Metodo per settare il tempo dopo il quale la lampada si spegne
        public void turnOffAfterDuration(int duration)
        {
            if (duration >= 60)
            {
                DurationBeforeOff = duration;

            }
            else
            {
                throw new ArgumentOutOfRangeException("Duration must be at least 60 seconds.");
            }
        }

        //Metodo per settare la classe energetica limitata alle classi A, A+, A++, A+++
        public override void setEnergyClass(string energyClassValue)
        {
            if (energyClassValue == "A")
            {
                EnergyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "Aa")
            {
                EnergyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "Aaa")
            {
                EnergyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "Aaaa")
            {
                EnergyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else
            {
                throw new ArgumentException("Invalid energy class. Allowed values are A, Aa, Aaa, Aaaa.");

            }

        }
    }

}