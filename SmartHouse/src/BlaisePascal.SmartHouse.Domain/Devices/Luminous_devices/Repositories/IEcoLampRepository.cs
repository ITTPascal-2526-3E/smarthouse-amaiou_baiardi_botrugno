using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories
{
    public interface IEcoLampRepository
    {
        void Add(EcoLamp ecolamp);
        void Update(EcoLamp ecolamp);
        void Remove(Guid id);
        Door GetById(Guid id);
        List<EcoLamp> GetAll();
    }
}
