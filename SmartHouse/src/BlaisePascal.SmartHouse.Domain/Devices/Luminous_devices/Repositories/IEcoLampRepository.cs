using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
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
        EcoLamp GetById(Guid id);
        List<EcoLamp> GetAll();
    }
}

