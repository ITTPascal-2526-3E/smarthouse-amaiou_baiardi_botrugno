using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application
{
    internal class GetFryerByIdQuery
    {
        private readonly IFryerRepository _repository;

        public GetFryerByIdQuery(IFryerRepository repository)
        {
            _repository = repository;
        }

        public Fryer Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}