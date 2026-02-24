using BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices
{
    public class ChangeDoorCloseCommand
    {
        private IDoorRepository _repository;
        public ChangeDoorCloseCommand(IDoorRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid doorId)
        {
            var door = _repository.GetById(doorId);
            if (door != null)
            {
                door.changeDoorState();
                _repository.Update(door);
            }
        }
    }
}