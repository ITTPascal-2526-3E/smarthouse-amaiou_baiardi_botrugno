using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public sealed class TwoLampsDevice
    {
        private Lamp lamp = new Lamp(0.0, 0, 0, 6,"vitto");
        private EcoLamp ecoLamp = new EcoLamp(0.0, 0, 0, 6);

        //chiama il costruttore della classe Lamp e assegna l'istanza alla variabile lamp
        public void setLampAttributes(Lamp lamp)
        {
            this.lamp = lamp;
        }

        //usa il metodo per ottenere il tipo di lampada
        public void setLampType(string lampTypeValue)
        {
            lamp.setLampType(lampTypeValue);
        }

        //usa il metodo per ottenere la classe energetica
        public void setEnergyClass(string energyClassValue)
        {
            lamp.setEnergyClass(energyClassValue);
        }

        //usa il metodo per accendere/spegnere la lampada
        public void turnOn()
        {
            lamp.TurnOn();
        }
        public void turnOff()
        {
            lamp.TurnOff();
        }

        //usa il metodo per cambiare il colore della lampada
        public void changeColor(string colorValue)
        {
            lamp.changeColor(colorValue);
        }

        //usa il metodo per impostare la luminosità della lampada
        public void setBrightness(int brightness)
        {
            lamp.brightness = brightness;
        }

        //chiama il costruttore della classe EcoLamp e assegna l'istanza alla variabile ecoLamp
        public void setEcoLampAttributes(EcoLamp ecoLamp)
        {
            this.ecoLamp = ecoLamp;
        }

        //usa il metodo per ottenere il tipo di lampada eco
        public void setEcoLampType(string lampTypeValue)
        {
            ecoLamp.setLampType(lampTypeValue);
        }

        //usa il metodo per ottenere la classe energetica della lampada eco
        public void setEcoLampEnergyClass(string energyClassValue)
        {
            ecoLamp.setEnergyClass(energyClassValue);
        }

        //usa il metodo per accendere/spegnere la lampada eco

        public void ecoLampTurnOn()
        {
            ecoLamp.TurnOn();
        }
        public void ecoLampTurnOff()
        {
            ecoLamp.TurnOff();
        }

        //usa il metodo per cambiare il colore della lampada eco
        public void ecoLampChangeColor(string colorValue)
        {
            ecoLamp.changeColor(colorValue);
        }
        
        //usa il metodo per impostare la luminosità della lampada eco
        public void ecoLampSetBrightness(int brightnessValue)
        {
            ecoLamp.brightness = brightnessValue;
        }

        //usa il metodo per impostare il tempo dopo il quale la lampada eco si spegne
        public void turnOffAfterDuration(int duration)
        {
            ecoLamp.turnOffAfterDuration(duration);
        }
    }
}
