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
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name = " ";
        public bool isOn = false;
        private LampType lampType { get; set; }
        private double lampHeat { get; set; }
        private EnergyClass energyClass { get; set; }
        private int brightness;
        private int lumen { get; set; }
        public Color color { get; set; }
        private int durationBeforeItFlashes { get; set; }
        private int durationBeforeOff;
        private int minBrightenes = 0;
        private int maxBrightenes = 100;

        public int brightnessProperty
        {
            get { return brightness; }
            set
            {
                if (brightness >= minBrightenes && brightness <= maxBrightenes)
                {
                    brightness = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100.");
                }
            }
        }




        //Metodo per settare il tempo dopo il quale la lampada si spegne
        public void turnOffAfterDuration(int duration)
        {
            if (duration >= 60)
            {
                durationBeforeOff = duration;

            }
            else
            {
                throw new ArgumentOutOfRangeException("Duration must be at least 60 seconds.");
            }
        }

        //Metodo per settare la classe energetica limitata alle classi A, A+, A++, A+++
        public void setEnergyClass(string energyClassValue)
        {
            if (energyClassValue == "A")
            {
                energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "A+")
            {
                energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "A++")
            {
                energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "A+++")
            {
                energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else
            {
                throw new ArgumentException("Invalid energy class. Allowed values are A, A+, A++, A+++.");

            }

        }

        //Metodo per settare la luminosità da 0 a 100
        public void setBrightness(int brightnessValue)
        {
            if (brightnessValue >= 0 && brightnessValue <= 100)
            {
                brightness = brightnessValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100.");
            }
        }

        //Metodo per settare il colore solo se la lampada è di tipo led
        public void setColor(string color)
        {
            if (lampType == LampType.led)
            {
                this.color = Enum.Parse<Color>(color);
            }
            else
            {
                throw new InvalidOperationException("Color can only be set for LED lamps.");
            }
        }
        public void setName(string EcoLampName)
        {
            name = EcoLampName;
        }
    }

}