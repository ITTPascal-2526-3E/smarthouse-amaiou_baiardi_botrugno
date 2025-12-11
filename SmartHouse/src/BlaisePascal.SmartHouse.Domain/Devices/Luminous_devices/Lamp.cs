using System.Runtime.InteropServices;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public class Lamp
    {
        //Creazione variabili/attributi
        public Guid Id { get; protected set; }
        public bool IsOn { get; protected set; }
        public LampType LampType { get; protected set; }
        public double LampHeat { get; protected set; }
        public EnergyClass EnergyClass { get;protected set; }
        public int brightness;
        public int Lumen { get;protected set; }
        public Color Color { get; protected set; }
        public int DurationBeforeItFlashes { get; protected set; }

        private int minBrightenes = 0;
        private int maxBrightenes = 100;
        
        public Lamp(double lampHeat, int lumen, int durationBeforeItFlashes)
        {
            Id = Guid.NewGuid();
            IsOn = false;
            this.LampHeat = lampHeat;
            this.Lumen = lumen;
            this.DurationBeforeItFlashes = durationBeforeItFlashes;
        }

        public LampType getLampType(string lamptype)      //Prende una stringa (lampType, ad es. "Led")  
        {                                                 //poi Controlla se esiste un valore dell’enum LampType con quel nome e infine
            LampType = Enum.Parse<LampType>(lamptype);    //restituisce il valore dell’enum corrispondente.
            return LampType;
        }

        public virtual void getEnergyClass (string energyClass)       
        {                
            this.EnergyClass = Enum.Parse<EnergyClass>(energyClass);
        }

        public void turnOn_Off()   //Cambia lo stato della lampada (accesa/spenta)
        {
            if (IsOn == true)
            {
                IsOn = false;
            }
            else
            {
                IsOn = true;
            }
        }

        public void changeColor(string color)   //Cambia il colore della lampada
        {
            if (LampType == LampType.led)
            {
                this.Color = Enum.Parse<Color>(color);
            }
            else
            {
                throw new InvalidOperationException("Color can be changed only for LED lamps.");
            }
        }

        public void setBrightness(int brightness)
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