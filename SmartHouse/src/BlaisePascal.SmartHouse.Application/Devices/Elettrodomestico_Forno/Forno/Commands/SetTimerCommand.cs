using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Elettrodomestico_Forno.Forno.Commands
{
    public class SetTemperaturaCommand
    {
        private readonly IFornoRepository _repository;

        public SetTemperaturaCommand(IFornoRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int temperatura)
        {
            var forno = _repository.GetById(id);

            if (forno == null)
                throw new Exception("Forno non trovato");

            forno.SetTemperatura(temperatura);

            _repository.Update(forno);
        }
    }
}
