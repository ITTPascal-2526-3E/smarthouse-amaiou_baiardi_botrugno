using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices
{
    public class TwoLampsDevice
    {
        private Lamp lamp = new Lamp(0.0, 0, 0);
        private EcoLamp ecoLamp = new EcoLamp(0.0, 0, 0);

        //chiama il costruttore della classe Lamp e assegna l'istanza alla variabile lamp
        public void getLampAttributes(Lamp lamp)
        {
            this.lamp = lamp;
        }

        //usa il metodo per ottenere il tipo di lampada
        public void getLampType(string lampTypeValue)
        {
            lamp.getLampType(lampTypeValue);
        }

        //usa il metodo per ottenere la classe energetica
        public void getEnergyClass(string energyClassValue)
        {
            lamp.getEnergyClass(energyClassValue);
        }

        //usa il metodo per accendere/spegnere la lampada
        public void turnOn_Off()
        {
            lamp.turnOn_Off();
        }

        //usa il metodo per cambiare il colore della lampada
        public void changeColor(string colorValue)
        {
            lamp.changeColor(colorValue);
        }

        //usa il metodo per impostare la luminosità della lampada
        public void setBrightness(int brightnessValue)
        {
            lamp.brightness = brightnessValue;
        }

        //chiama il costruttore della classe EcoLamp e assegna l'istanza alla variabile ecoLamp
        public void getEcoLampAttributes(EcoLamp ecoLamp)
        {
            this.ecoLamp = ecoLamp;
        }

        //usa il metodo per ottenere il tipo di lampada eco
        public void getEcoLampType(string lampTypeValue)
        {
            ecoLamp.getLampType(lampTypeValue);
        }

        //usa il metodo per ottenere la classe energetica della lampada eco
        public void getEcoLampEnergyClass(string energyClassValue)
        {
            ecoLamp.getEnergyClass(energyClassValue);
        }

        //usa il metodo per accendere/spegnere la lampada eco

        public void ecoLampTurnOn_Off()
        {
            ecoLamp.turnOn_Off();
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
