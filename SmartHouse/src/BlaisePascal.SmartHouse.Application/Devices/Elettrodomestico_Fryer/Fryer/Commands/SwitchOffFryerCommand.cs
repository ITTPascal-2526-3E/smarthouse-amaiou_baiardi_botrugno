using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices
{
    public class SwitchOffFryerCommand
    {
        private IFryerRepository _repository;
        public SwitchOffFryerCommand(IFryerRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid fryerId)
        {
            var fryer = _repository.GetById(fryerId);
            if (fryer != null)
            {
                fryer.TurnOff();
                _repository.Update(fryer);
            }
        }
    }
}