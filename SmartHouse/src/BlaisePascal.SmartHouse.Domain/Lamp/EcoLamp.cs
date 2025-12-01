using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.LampType
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
            }
        }




        //Metodo per settare il tempo dopo il quale la lampada si spegne
        public void turnOffAfterDuration(int duration)
        {
            if (duration >= 60)
            {
                this.durationBeforeOff = duration;

            }
            else
            {

            }
        }

        //Metodo per settare la classe energetica limitata alle classi A, A+, A++, A+++
        public void setEnergyClass(string energyClassValue)
        {
            if (energyClassValue == "A")
            {
                this.energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "A+")
            {
                this.energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "A++")
            {
                this.energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else if (energyClassValue == "A+++")
            {
                this.energyClass = Enum.Parse<EnergyClass>(energyClassValue);
            }
            else
            {

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

            }
        }

        //Metodo per settare il colore solo se la lampada è di tipo led
        public void setColor(string color)
        {
            if (this.lampType == LampType.led)
            {
                this.color = Enum.Parse<Color>(color);
            }
            else
            {

            }
        }
        public void setName(string EcoLampName)
        {
            name = EcoLampName;
        }
    }

}