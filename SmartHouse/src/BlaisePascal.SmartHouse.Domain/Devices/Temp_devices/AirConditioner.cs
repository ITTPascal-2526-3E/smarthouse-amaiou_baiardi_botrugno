using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlaisePascal.SmartHouse.Domain.Devices.Temp_devices.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain.Devices.Temp_devices
{
    public sealed class AirConditioner : Iswitchable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double temp { get; set; }
        private const double minTemp = 16.0;
        private const double maxTemp = 25.0;
        public enum funSpeed { Low, Medium, High }
        public bool energySavingMode = false;
        private string name = " ";
        public bool status = false;


        public AirConditioner(double initialTemp)
        {
            Id = Guid.NewGuid();
            if (initialTemp >= minTemp && initialTemp <= maxTemp)
            {
                temp = initialTemp;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Initial temperature must be between {minTemp} and {maxTemp} degrees Celsius.");
            }
        }

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

        public void PutInEnergySavingMode()
        {
            if (energySavingMode == false)
            {
                energySavingMode = true;
            }
            else
            {
                throw new InvalidOperationException("AirConditioner is already in energy saving mode.");
            }
        }

        public void changefunspeed()
        {
            if (status == true)
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
            else
            {
                throw new InvalidOperationException("AirConditioner is off. Cannot change fan speed.");
            }
        }
        public void increaseTemp()
        {
            if (status == true)
            {
                if (temp < maxTemp)
                {
                    temp += 1.0;
                }
            }
            else
            {
                throw new InvalidOperationException("AirConditioner is off. Cannot increase temperature.");
            }
        }
        public void decreaseTemp()
        {
            if (status == true)
            {
                if (temp > minTemp)
                {
                    temp -= 1.0;
                }
            }
            else
            {
                throw new InvalidOperationException("AirConditioner is off. Cannot decrease temperature.");
            }
        }
        public void setName(string airConditionerName)
        {
            if (string.IsNullOrWhiteSpace(airConditionerName))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(airConditionerName));
            }
            else
            {
                name = airConditionerName;
            }
        }

    }
}