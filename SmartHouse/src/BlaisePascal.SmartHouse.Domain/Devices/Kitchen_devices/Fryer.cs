using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices
{
    public class Fryer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private string type;// a olio o ad aria

        public string typeProperty
        {
            get { return type; }
            set
            {
                if (type == "olio" || type == "aria")
                {
                    type = value;
                }
            }
        }

        public bool isOn = false;
        private string basketStatus = "down";  // status basket può essere down o up
        private int temperature { get; set; }
        public int numberOfFryerBeforeChangeOil { get; set; }

        private int minTemp = 175; // temperature standard di una friggitrice vera prese da Google
        private int maxTemp = 200;

        private int max_numberOfFryer_BeforeChangeOil = 10;
        private int min_numberOfFryer_BeforeChangeOil = 3;

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

        public void change_NumberOfFryer_BeforeChangeOil(int value)
        {
            if (value >= min_numberOfFryer_BeforeChangeOil && value <= max_numberOfFryer_BeforeChangeOil)
            { numberOfFryerBeforeChangeOil = value; }
        }
    }
}
