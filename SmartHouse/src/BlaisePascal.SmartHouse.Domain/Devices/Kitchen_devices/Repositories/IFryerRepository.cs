using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories
{
    public interface IFryerRepository
    {
        void Add(Fryer fryer);
        void Update(Fryer fryer);
        void Remove(Guid id);
        Door GetById(Guid id);
        List<Fryer> GetAll();
    }
}
