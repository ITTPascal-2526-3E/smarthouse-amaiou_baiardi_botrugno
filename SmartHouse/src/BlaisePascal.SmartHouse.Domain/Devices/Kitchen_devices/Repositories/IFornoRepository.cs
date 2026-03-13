using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;

namespace BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories
{
    public interface IFornoRepository
    {
        void Add(Forno forno);
        void Update(Forno forno);
        void Remove(Guid id);
        Forno GetById(Guid id);
        List<Forno> GetAll();
    }
}
