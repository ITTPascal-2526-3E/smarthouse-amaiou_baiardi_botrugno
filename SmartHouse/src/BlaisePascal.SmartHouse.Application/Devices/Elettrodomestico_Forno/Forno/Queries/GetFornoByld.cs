using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;

namespace BlaisePascal.SmartHouse.Application.Devices.Elettrodomestico_forno.forno.Queries
{
    public class GetFornoByIdQuery
    {
        private readonly IFornoRepository _repository;

        public GetFornoByIdQuery(IFornoRepository repository)
        {
            _repository = repository;
        }

        public Forno Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
