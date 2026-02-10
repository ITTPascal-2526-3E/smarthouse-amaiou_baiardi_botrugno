using BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public interface IAlarmRepository
    {
        void Add(Alarm alarm);
        void Update(Alarm alarm);
        void Remove(Guid id);
        Alarm GetById(Guid id);
        List<Alarm> GetAll();
    }
}
