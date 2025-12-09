using System.Runtime.InteropServices;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public class Lamp
    {
        //Creazione variabili/attributi
        public Guid Id { get; set; }
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
        
        public EnergyClass getEnergyClass (string energyClass)       
        {                
            this.energyClass = Enum.Parse<EnergyClass>(energyClass);    
            return this.energyClass;
        }

        public void changeState()   //Cambia lo stato della lampada (accesa/spenta)
        {
            if (isOn == true)
            {
                isOn = false;
            }
            else
            {
                isOn = true;
            }
        }

        public LampType getLampType(string lamptype)      //Prende una stringa (lampType, ad es. "Led")  
        {                                                 //poi Controlla se esiste un valore dell’enum LampType con quel nome e infine
            lampType = Enum.Parse<LampType>(lamptype);    //restituisce il valore dell’enum corrispondente.
            return lampType;
        }



        public void getBrightness(int brightness)
        {
            if (brightness >= minBrightenes && brightness <= maxBrightenes)
            {
                this.brightness = brightness;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Brightness must be in range");
            }
        }
       
    }
}