using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using System.Collections.Generic;

namespace BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories
{
    public interface ILampRepository
    {
        // Recupera tutte le lampade (comprese le EcoLamp grazie al polimorfismo)
        List<Lamp> GetAll();

        // Recupera una lampada specifica per ID
        Lamp GetById(Guid id);

        // Aggiunge una nuova lampada (accetta sia Lamp che EcoLamp)
        void AddLamp(Lamp lamp);

        // Rimuove una lampada tramite il suo ID
        void RemoveLamp(Guid id);

        // Il metodo "Re" della persistenza: salva qualsiasi modifica allo stato
        void Update(Lamp lamp);
    }
}


