using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class Volume
    {
        public int value { get; set;}
        public Volume(int volume)
        {
            if (volume < 0 || volume > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if () { }

        }
    }
}
