using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices
{
    public class Fryer
    {
        private string type;// a olio o ad aria
        public bool isOn = false;
        private string basketStatus;  // status basket può essere down o up
        private double temperature { get; set; }
        public int numberOfFryerBeforeChangeOil { get; set; }

        private const double minTemp = 160.0; // temperature standard di una friggitrice vera prese da Google
        private const double maxTemp = 220.0;

        private const int max_numberOfFryer_BeforeChangeOil = 10;
        private const int min_numberOfFryer_BeforeChangeOil = 3;

        
        public Fryer(double startTemperature, int defaultNumberOfFryerBeforeChangeOil)
        {
            
            isOn = false;
            basketStatus = "down";
            temperature = startTemperature; // temperatura di default
            numberOfFryerBeforeChangeOil = defaultNumberOfFryerBeforeChangeOil; // numero di fritture di default
        }

        public void setFryerType(string type)
        {
            if (type != "oil" && type != "air")
            {
                throw new ArgumentException("Invalid fryer type. It must be either 'oil' or 'air'.");
            }
            else
            {
                this.type = type;
            }
        }   
        public void changeStatus()
        {
            if (isOn == true)
            {
                isOn = false;
            }
            else
                isOn = true;
        }

        public void changeBasketStatus()
        {
            if (basketStatus == "up")
                basketStatus = "down";
            else
                basketStatus = "up";
        }

        public void changeTemp(double value)
        {
            if (value >= minTemp && value <= maxTemp)
            { temperature = value; }
            else
            {
                throw new ArgumentOutOfRangeException("Temperature must be between 160 and 220 degrees Celsius.");
            }
        }

        public void change_NumberOfFryer_BeforeChangeOil(int value)
        {
            if (value >= min_numberOfFryer_BeforeChangeOil && value <= max_numberOfFryer_BeforeChangeOil)
            { numberOfFryerBeforeChangeOil = value; }
            else
            {
                throw new ArgumentOutOfRangeException($"Number of fryings before changing oil must be between {min_numberOfFryer_BeforeChangeOil} and {max_numberOfFryer_BeforeChangeOil}.");
            }
        }
    }
}
