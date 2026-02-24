using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices
{
    public class SwitchOn_CCTV_Command
    {
        private ICCTVRepository _repository;
        public SwitchOn_CCTV_Command(ICCTVRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid cctvId)
        {
            var cctv = _repository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.TurnOff();
                _repository.Update(cctv);
            }
        }
    }
}