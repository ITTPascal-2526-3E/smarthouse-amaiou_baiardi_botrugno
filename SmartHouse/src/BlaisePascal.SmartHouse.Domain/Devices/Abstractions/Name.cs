using System;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class Name
    {
        // Proprietà in sola lettura: un Value Object non deve cambiare stato dopo la creazione
        public string Value { get; }

        public Name(string name)
        {
            // 1. Validazione: Null o vuoto
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            // 2. Validazione: Lunghezza minima
            if (name.Length < 3)
            {
                throw new ArgumentException("Name must be at least 3 characters long.", nameof(name));
            }

            // 3. Validazione: Lunghezza massima
            if (name.Length > 50)
            {
                throw new ArgumentException("Name cannot exceed 50 characters.", nameof(name));
            }

            // 4. Validazione: Formattazione (Inizia con lettera Maiuscola)
            if (char.IsLetter(name[0]) && char.IsUpper(name[0]))
            {
                Value = name;
            }
            else
            {
                throw new ArgumentException("Name must start with an uppercase letter.", nameof(name));
            }
        }

        /// <summary>
        /// Factory Method: permette di creare un Name scrivendo Name.From("Esempio")
        /// </summary>
        public static Name From(string name) => new Name(name);

        /// <summary>
        /// Override di ToString per usare l'oggetto direttamente in stringhe o Console.WriteLine
        /// </summary>
        public override string ToString() => Value;

        // Nota: In un Value Object "puro" andrebbero sovrascritti anche Equals e GetHashCode,
        // ma per ora questo copre perfettamente le tue necessità nel progetto.
    }
}