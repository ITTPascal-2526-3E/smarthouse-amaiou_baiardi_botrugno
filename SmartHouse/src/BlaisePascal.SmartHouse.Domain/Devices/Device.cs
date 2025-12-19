using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public class Device 
    {
       
        public bool status { get; protected set; }
      
        public Device() 
        { 
            status = false;
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
    }
}
