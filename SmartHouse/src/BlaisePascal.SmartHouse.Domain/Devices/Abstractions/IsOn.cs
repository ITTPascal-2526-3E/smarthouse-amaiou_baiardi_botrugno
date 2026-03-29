using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class IsOn
    {
        public bool value { get; set; }
        public IsOn(bool IsOn)
        {
            if (IsOn != null) 
            {
                value = IsOn;
            }
            else
            {
                throw new ArgumentException("IsOn cannot be null.", nameof(IsOn));
            }
            
        }
    }
}
