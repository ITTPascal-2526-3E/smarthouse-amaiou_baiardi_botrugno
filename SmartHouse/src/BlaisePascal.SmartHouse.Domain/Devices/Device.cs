using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public class Device 
    {
        public Guid id { get; protected set; }
        public string name { get; protected set; }
        public bool status { get; protected set; }
        public string timeOfCreation { get; protected set; }
        public string lastTimeModified { get; protected set; }
        public Device(string Name, bool Status, string TimeOfCreation,string LastTimeModified) 
        { 
            id = Guid.NewGuid();
            name = Name;
            status = Status;
            timeOfCreation = TimeOfCreation;
            lastTimeModified = LastTimeModified;
        }
    }
}
