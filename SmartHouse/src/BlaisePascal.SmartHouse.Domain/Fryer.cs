using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Fryer
    {
        private string type { get; set; } // a olio o ad aria
        public bool isOn = false;
        private string basketStatus = "down";  // status basket può essere down o up
        private int temperature { get; set; }
        public int numberOfFryerBeforeChangeOil { get; set; }

        private int minTemp = 175; // temperature standard di una friggitrice vera prese da Google
        private int maxTemp = 200;

        public void changeStatus()
        {
            isOn = true;
        }

        public void changeBasketStatus()
        {
            basketStatus = "up";
        }

        public void changeTemp(int value)
        {
            if (value >= minTemp && value <= maxTemp)
            { temperature = value; }
        }

        public void changeNumberOfFryerBeforeChangeOil(int value)
        {
            // aggiungere un if per il controllo del value
            { numberOfFryerBeforeChangeOil = value; }
        }
    }
}

