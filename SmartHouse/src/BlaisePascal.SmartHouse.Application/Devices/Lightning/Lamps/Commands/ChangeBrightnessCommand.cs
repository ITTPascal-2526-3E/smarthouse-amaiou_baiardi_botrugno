using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands
{
    public class ChangeBrightnessCommand
    {
        private readonly ILampRepository _repository;
        public ChangeBrightnessCommand(ILampRepository repository) => _repository = repository;

        public void Execute(Guid lampId, byte brightness)
        {
            var lamp = _repository.GetById(lampId);
            if (lamp != null)
            {
                lamp.setBrightness(brightness);
                _repository.Update(lamp);
            }
        }
    }
}
