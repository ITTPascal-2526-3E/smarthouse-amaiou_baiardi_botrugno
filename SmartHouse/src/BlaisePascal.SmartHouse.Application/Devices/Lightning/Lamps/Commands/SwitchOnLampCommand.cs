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
    public class SwitchOnLampCommand
    {
        private ILampRepository _repository;
        public SwitchOnLampCommand(ILampRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid lampId)
        {
            var lamp = _repository.GetById(lampId);
            if (lamp != null)
            {
                lamp.TurnOn();
                _repository.Update(lamp);
            }
        }
    }
}