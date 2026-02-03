using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public abstract class SecurityDevice : ISecurity, Iswitchable
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public bool IsOn { get; protected set; }
        public bool IsArmed { get; protected set; }

        public virtual void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
            }
            else
            {
                throw new InvalidOperationException("Device is already on.");
            }
        }
        public virtual void TurnOff()
        {
            if (!IsOn)
                throw new InvalidOperationException("Device already off.");

            IsOn = false;
            IsArmed = false; // spegnendo disarmi
        }

        public virtual void Arm()
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot arm a device that is off.");
            if (!IsArmed)
            {
                IsArmed = true;
            }
            else
            {
                throw new InvalidOperationException("Device is already armed.");
            }
        }

        public virtual void Disarm()
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot disarm a device that is off.");
            if (IsArmed == true)
            {
                IsArmed = false;
            }
            else
            {
                throw new InvalidOperationException("Device is already disarmed.");
            }
        }
    }
}
