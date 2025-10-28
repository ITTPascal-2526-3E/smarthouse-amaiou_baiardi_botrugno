using System.Runtime.InteropServices;

namespace BlaisePascal.SmartHouse.LampType
{
    public class Lamp
    {
        //Creazione variabili/attributi
        public bool isOn = false;
        private LampType lampType { get; set; }
        private double lampHeat {  get; set; }
        private EnergyClass energyClass {  get; set; }
        private int brightness;
        private int lumen {  get; set; }
        public Color color;
        private int durationBeforeItFlashes {  get; set; }

        private int minBrightenes = 0;
        private int maxBrightenes = 100;

        public LampType lampTypeProperty
        {
            get { return lampType; }
            set { lampType = value; }
        }

        

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
        
       
        
    }
}