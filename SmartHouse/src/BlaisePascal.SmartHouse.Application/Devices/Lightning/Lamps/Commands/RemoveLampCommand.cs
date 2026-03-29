using System;
using System.Linq;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;

namespace BlaisePascal.SmartHouse.Application
{
    public class RemoveLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        // Accetta il Value Object Name per cercare la lampada
        public void Execute(Name name)
        {
            // 1. Recuperiamo tutte le lampade
            var lamps = _lampRepository.GetAll();

            // 2. Cerchiamo la lampada che ha lo stesso nome (confrontando le stringhe Value)
            var lampToRemove = lamps.FirstOrDefault(l =>
                l.Name.Equals(name.Value, StringComparison.OrdinalIgnoreCase));

            // 3. Validazione: se non esiste, lanciamo un'eccezione
            if (lampToRemove == null)
            {
                throw new InvalidOperationException($"Errore: Nessuna lampada trovata con il nome '{name.Value}'.");
            }

            // 4. Rimozione tramite ID
            _lampRepository.RemoveLamp(lampToRemove.Id);
        }
    }
}
