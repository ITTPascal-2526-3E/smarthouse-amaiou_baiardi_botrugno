using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightining.Lamps
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>();

            // Popolamento iniziale corretto
            _lamps.Add(new Lamp(10.0, 20, 2, 12, new Name("Luke")));
        }

        public void AddLamp(Lamp lamp)
        {
            if (lamp == null) throw new ArgumentNullException(nameof(lamp));

            // Evitiamo duplicati se necessario
            if (!_lamps.Any(l => l.Id == lamp.Id))
            {
                _lamps.Add(lamp);
            }
        }

        public List<Lamp> GetAll()
        {
            // Restituiamo una copia della lista per proteggere i dati interni
            return _lamps.ToList();
        }

        public Lamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(l => l.Id == id);
        }

        public void RemoveLamp(Guid id)
        {
            var lamp = GetById(id);
            if (lamp != null)
            {
                _lamps.Remove(lamp);
            }
        }

        public void Update(Lamp lamp)
        {
            if (lamp == null) return;

            // Cerchiamo la lampada esistente
            var index = _lamps.FindIndex(l => l.Id == lamp.Id);

            if (index != -1)
            {
                // In memoria, l'oggetto potrebbe essere lo stesso, 
                // ma sostituirlo garantisce che i dati siano aggiornati.
                _lamps[index] = lamp;
            }
        }
    }
}



