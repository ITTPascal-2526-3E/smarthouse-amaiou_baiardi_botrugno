using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlaisePascal.SmartHouse.Domain.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner
    {
        public bool isOn = false;
        public double temp { get; set; }
        private double minTemp = 16.0;
        private double maxTemp = 25.0;
        public enum funSpeed { Low, Medium, High }
        public bool energySavingMode = false;

        public void turnOn()
        {
            isOn = true;
        }
        public void turnOff(int time)
        {
            if (isOn == true && time > 0 && time <= 30)
            {
                for (int i = 0; i == time; i++)
                {
                    if (i == time)
                    {
                        isOn = false;
                    }

                }
            }
        }
        public void PutInEnergySavingMode()
        {
            energySavingMode = true;
        }

        public void changefunspeed()
        {
            if (isOn == true)
            {
                funSpeed currentSpeed = funSpeed.Low;
                switch (currentSpeed)
                {
                    case funSpeed.Low:
                        currentSpeed = funSpeed.Medium;
                        break;
                    case funSpeed.Medium:
                        currentSpeed = funSpeed.High;
                        break;
                    case funSpeed.High:
                        currentSpeed = funSpeed.Low;
                        break;
                }

            }

        }
        public void increaseTemp()
        {
            if (isOn == true)
            {
                if (temp < maxTemp)
                {
                    temp += 1.0;
                }
            }
        }
        public void decreaseTemp()
        {
            if (isOn == true)
            {
                if (temp > minTemp)
                {
                    temp -= 1.0;
                }
            }
        }

    }
}
