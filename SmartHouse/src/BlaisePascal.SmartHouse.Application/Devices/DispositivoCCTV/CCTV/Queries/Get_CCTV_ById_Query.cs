using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application
{
    internal class Get_CCTV_ById_Query
    {
        private readonly ICCTVRepository _repository;

        public Get_CCTV_ById_Query(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public cctv Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}