using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System;
using System.Xml.Linq;
namespace BlaisePascal.SmartHouse.Application.Devices.Elettrodomestico_forno.forno.Commands
{
    public class CreateFornoCommand
    {
        private readonly IFornoRepository _repository;

        public CreateFornoCommand(IFornoRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name)
        {
            var forno = new Forno(Guid.NewGuid(), new Name(name));
            _repository.Add(forno);
        }
    }
}
