using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using System.Runtime.InteropServices;
using System.Xml.Linq;
namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public class Lamp : Iswitchable, IsetLuminousDeviceSettings
    {
        //Creazione variabili/attributi
        public Guid Id { get; set; }
        public string Name { get; protected set; }
        public LampType LampType { get; protected set; }
        public double LampHeat { get; protected set; }
        public EnergyClass EnergyClass { get; protected set; }
        public int brightness { get; set; }
        public int Lumen { get; protected set; }
        public Color color { get; set; }
        public int DurationBeforeItFlashes { get; protected set; }

        private const int minBrightenes = 0;
        private const int maxBrightenes = 100;
        public bool status = false;

        //Costruttore di Lamp
        public Lamp(double lampHeat, int lumen, int durationBeforeItFlashes, int Initialbrightness, Name name)
        {
            Id = Guid.NewGuid();
            status = false;
            this.LampHeat = lampHeat;
            this.Lumen = lumen;
            this.DurationBeforeItFlashes = durationBeforeItFlashes;
            this.brightness = Initialbrightness;
            this.Name = name.Value;
        }
        // accendi e spegni la lampada
        public void TurnOn()
        {
            if (status == false)
            {
                status = true;
            }
            else
            {
                throw new InvalidOperationException("Device is already on.");
            }
        }
        public void TurnOff()
        {
            if (status == true)
            {
                status = false;
            }
            else
            {
                throw new InvalidOperationException("Device is already off.");
            }
        }
        //poi Controlla se esiste un valore dell’enum LampType con quel nome e infine
        //restituisce il valore dell’enum corrispondente.
        public LampType setLampType(string lamptype)      //Prende una stringa (lampType, ad es. "Led")  
        {
            if (!Enum.IsDefined(typeof(LampType), lamptype))
            {
                throw new ArgumentException("Invalid lamp type");
            }
            LampType = Enum.Parse<LampType>(lamptype);
            return LampType;
        }

        public virtual void setEnergyClass(string energyClass)
        {
            if (!Enum.IsDefined(typeof(EnergyClass), energyClass))
            {
                throw new ArgumentException("Invalid energy class");
            }
            this.EnergyClass = Enum.Parse<EnergyClass>(energyClass);
        }



        //Cambia il colore della lampada
        public void changeColor(string color)
        {
            if (LampType == LampType.led)
            {
                this.color = Enum.Parse<Color>(color);
            }
            else
            {
                throw new InvalidOperationException("Color can be changed only for LED lamps.");
            }
        }
        public Color getColor()
        {
            if (LampType == LampType.led)
            {
                return color;
            }
            else
            {
                throw new InvalidOperationException("Color can be changed only for LED lamps.");
            }
        }
        //Imposta la luminosità della lampada
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
        public string getName()
        {
            return Name;
        }

    }
}
