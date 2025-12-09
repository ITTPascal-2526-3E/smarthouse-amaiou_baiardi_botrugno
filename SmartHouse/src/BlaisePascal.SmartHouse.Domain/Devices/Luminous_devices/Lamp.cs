using System.Runtime.InteropServices;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public class Lamp
    {
        //Creazione variabili/attributi
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool isOn { get; set; }
        public LampType lampType { get; set; }
        private double lampHeat { get; set; }
        private EnergyClass energyClass { get; set; }
        public int brightness;
        private int lumen { get; set; }
        public Color color;
        private int durationBeforeItFlashes { get; set; }

        private int minBrightenes = 0;
        private int maxBrightenes = 100;

        public LampType lampTypeProperty(string lamptype) //Prende una stringa (lampType, ad es. "Led")  
        {                                                 //poi Controlla se esiste un valore dell’enum LampType con quel nome e infine
            lampType = Enum.Parse<LampType>(lamptype);    //restituisce il valore dell’enum corrispondente.
            return lampType;
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
                else
                {
                    throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100.");
                }
            }
        }
       
    }
}