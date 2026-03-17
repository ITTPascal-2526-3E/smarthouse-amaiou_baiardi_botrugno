using BlaisePascal.SmartHouse.Application;
using BlaisePascal.SmartHouse.Application.Devices;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Queries;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlaisePascal.SmartHouse.Domain.Controller
{
    public class LampController
    {
        private readonly ILampRepository _lampRepository;
        private readonly GetAllLampQuery _query; // Aggiunta la query come nel modello che ti piaceva

        public LampController(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
            _query = new GetAllLampQuery(_lampRepository);
        }
        public void ShowMenu()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Add a new Lamp");
            Console.WriteLine("2. Remove a Lamp");
            Console.WriteLine("3. Turn ON a Lamp");
            Console.WriteLine("4. Turn OFF a Lamp");
            Console.WriteLine("5. Change Brightness");
            Console.WriteLine("6. List all Lamps");
            Console.WriteLine("7. Back to Main Menu");
            Console.WriteLine("-----------------------------------");
        }

        // Metodo helper per trovare una lampada per nome o ID (scritto una volta, usato ovunque)
        private Lamp FindLamp(string input)
        {
            var list = _query.Execute();
            // Cerca per Nome (ignorando maiuscole) o per ID Guid
            return list.FirstOrDefault(l =>
                l.getName().Equals(input, StringComparison.OrdinalIgnoreCase) ||
                l.Id.ToString() == input);
        }

        public void AddLamp()
        {
            Console.Write("Enter lamp name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) return;

            try
            {
                // Usa il Command per aggiungere
                new AddLampCommand(_lampRepository).Execute(Name.From(name));
                Console.WriteLine("!Lamp added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        }

        public void RemoveLamp()
        {
            Console.Write("Enter lamp name or ID to remove: ");
            string input = Console.ReadLine();
            var lamp = FindLamp(input);

            if (lamp != null)
            {
                new RemoveLampCommand(_lampRepository).Execute(lamp.Id);
                Console.WriteLine($"!Lamp '{lamp.getName()}' removed!");
            }
            else
            {
                Console.WriteLine("Lamp not found.");
            }
        }

        public void TurnOnLamp()
        {
            Console.Write("Enter lamp name to switch on: ");
            string input = Console.ReadLine();
            var lamp = FindLamp(input);

            if (lamp != null)
            {
                new SwitchOnLampCommand(_lampRepository).Execute(lamp.Id);
                Console.WriteLine($"!Lamp '{lamp.getName()}' switched on!");
            }
            else
            {
                Console.WriteLine("Lamp not found.");
            }
        }

        public void TurnOffLamp()
        {
            Console.Write("Enter lamp name to switch off: ");
            string input = Console.ReadLine();
            var lamp = FindLamp(input);

            if (lamp != null)
            {
                new SwitchOffLampCommand(_lampRepository).Execute(lamp.Id);
                Console.WriteLine($"!Lamp '{lamp.getName()}' switched off!");
            }
            else
            {
                Console.WriteLine("Lamp not found.");
            }
        }

        public void ChangeIntensity()
        {
            Console.Write("Enter lamp name: ");
            string input = Console.ReadLine();
            var lamp = FindLamp(input);

            if (lamp != null)
            {
                Console.Write("Enter new brightness (0-100): ");
                if (byte.TryParse(Console.ReadLine(), out byte brightness))
                {
                    new ChangeBrightnessCommand(_lampRepository).Execute(lamp.Id, brightness);
                    Console.WriteLine($"!Brightness of '{lamp.getName()}' changed!");
                }
            }
            else
            {
                Console.WriteLine("Lamp not found.");
            }
        }

        public void ListLamps()
        {
            var lamps = _query.Execute();
            if (!lamps.Any())
            {
                Console.WriteLine("No lamps available.");
                return;
            }

            Console.WriteLine("\n---------- LAMPS ----------");
            foreach (var lamp in lamps)
            {
                Console.WriteLine($"Name: {lamp.getName()} | ID: {lamp.Id} | Status: {(lamp.status ? "On" : "Off")} | Brightness: {lamp.brightness}%");
            }
        }
    }
}
