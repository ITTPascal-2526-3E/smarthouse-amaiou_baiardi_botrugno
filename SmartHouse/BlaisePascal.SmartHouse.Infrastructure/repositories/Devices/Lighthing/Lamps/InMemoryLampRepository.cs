using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightining.Lamps
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>();
            {
                new Lamp(10.0, 20, 2, 12, new Name ("luke"));
            }
        }


        public void Add(Lamp lamp)
        {
            if (lamp == null)
            {
                throw new ArgumentNullException(nameof(lamp));
            }
            _lamps.Add(lamp);
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }


        public Lamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(l => l.Id == id);
        }

        public void Remove(Guid id)
        {
            foreach (var lamp in _lamps)
            {
                if (lamp.Id == id)
                {
                    _lamps.Remove(lamp);
                    break;
                }
            }
        }

        public void Update(Lamp lamp)
        {
            //
        }

    }


}

