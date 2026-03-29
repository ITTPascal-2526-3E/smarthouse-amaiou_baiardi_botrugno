using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Elettrodomestico_forno.forno.Commands
{
    public class DeleteFornoCommand
    {
        private readonly IFornoRepository _repository;

        public DeleteFornoCommand(IFornoRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
