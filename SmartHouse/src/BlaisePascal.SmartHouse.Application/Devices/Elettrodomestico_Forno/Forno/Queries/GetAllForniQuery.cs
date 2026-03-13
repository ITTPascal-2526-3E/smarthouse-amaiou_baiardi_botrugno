using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;

namespace BlaisePascal.SmartHouse.Application.Devices.Elettrodomestico_forno.forno.Queries
{
    public class GetAllForniQuery
    {
        private readonly IFornoRepository _repository;

        public GetAllForniQuery(IFornoRepository repository)
        {
            _repository = repository;
        }

        public List<Forno> Execute()
        {
            return _repository.GetAll();
        }
    }
}
