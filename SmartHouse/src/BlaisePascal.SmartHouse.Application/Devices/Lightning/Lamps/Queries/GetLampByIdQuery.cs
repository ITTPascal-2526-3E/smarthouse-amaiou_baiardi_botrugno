using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Queries
{
    internal class GetLampByIdQuery
    {
        private readonly ILampRepository _repository;

        public GetLampByIdQuery(ILampRepository repository)
        {
            _repository = repository;
        }

        public Lamp Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}