using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public interface ISecurity
    {
        Guid Id { get; }
        bool IsArmed { get; }

        void Arm();
        void Disarm();
    }
}
