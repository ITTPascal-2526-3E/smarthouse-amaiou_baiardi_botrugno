using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class Device
    {
        public string Name { get; private set; }
        public Device() { } 


        public void SetName(string name)
        {
            Name = name;
        }
    }
}
