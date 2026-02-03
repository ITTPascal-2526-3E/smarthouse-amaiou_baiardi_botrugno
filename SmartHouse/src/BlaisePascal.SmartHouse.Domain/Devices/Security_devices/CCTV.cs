using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public sealed class CCTV : SecurityDevice
    {
        public bool NightVision { get; private set; }
        public int ZoomLevel { get; private set; }

        public void ToggleNightVision()
        {
            if (!IsOn)
                throw new InvalidOperationException("CCTV must be on.");

            NightVision = !NightVision;
        }
    }
}