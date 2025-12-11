using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices
{
    public class Fryer
    {
        //Creazione variabili/attributi
        public Guid Id { get; private set; }
        public string Type { get; protected set; }
        public bool IsOn { get; protected set; }
        public bool BasketStatusUp { get;private set; }
        public double Temperature { get;private set; }

        private double minTemp = 160.0; // temperature standard di una friggitrice vera prese da Google
        private double maxTemp = 220.0;

        private int numberOfFryer_BeforeChangeOil = 3;// numero di utilizzi prima di dover cambiare l'olio
        private int currentNumberOfOilUses = 3;// numero di utilizzi rimanenti prima di dover cambiare l'olio

        //Costruttore di Fryer
        public Fryer()
        {
            Id = new Guid();
            IsOn = false;
        }

        //Metodo per settare il tipo di friggitrice limitato a olio o aria
        public void setType(string type)
        {
            if(type == "oil" || type == "air")
            {
                Type = type;
            }
            else
            {
                throw new InvalidOperationException("the frier type can only be oil or air");
            }
        }

        //Cambia lo stato della friggitrice (accesa/spenta)
        public void turnOn_Off()   
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

        //Cambia lo stato del cestello (su/giù)
        public void basketStatus()   
        {
            if (currentNumberOfOilUses == 0)
            {
                throw new InvalidOperationException("You need to change the oil before using the fryer.");
            }
            else
            {
                if (BasketStatusUp == true)
                {
                    BasketStatusUp = false;
                }
                else
                {
                    BasketStatusUp = true;
                }
            }
        }

        //Cambia la temperatura della friggitrice entro i limiti prestabiliti
        public void changeTemp(double value)
        {
            if (value >= minTemp && value <= maxTemp)
            { 
                Temperature = value; 
            }
            else
            {
                throw new ArgumentOutOfRangeException("Temperature must be between 160 and 220 degrees Celsius.");
            }
        }

        //Cambia l'olio della friggitrice resettando il contatore degli utilizzi
        public void changeOil()
        {
            currentNumberOfOilUses = numberOfFryer_BeforeChangeOil;
        }   


    }
}
