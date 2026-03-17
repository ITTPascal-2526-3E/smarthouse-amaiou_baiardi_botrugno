using System;
using BlaisePascal.SmartHouse.Domain.Controller;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightining.Lamps;

namespace BlaisePascal.SmartHouse.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- setup iniziali invariati ---
            ILampRepository lampRepository = new InMemoryLampRepository();
            lampRepository.AddLamp(new Lamp(35.0, 800, 5000, 60, new Name("Botru")));
            lampRepository.AddLamp(new EcoLamp(20.0, 400, 5000, 60, new Name("Vitto")));

            LampController lampController = new LampController(lampRepository);
            LampsRow salottoGroup = new LampsRow();
            salottoGroup.AddLamp(new Lamp(30, 500, 4000, 50, new Name("LampadaQuadro")));

            AirConditioner airConditioner = new AirConditioner(22.0);
            CCTV camera = new CCTV(new Name("Ake"));
            Door mainDoor = new Door(false, "Acciaio", true, false, 10.0, 5.0, 4.0, new Name("Ingresso"));
            Fryer fryer = new Fryer(180.0, 5, "Olio", new Name("FriggitriceCucina"));
            Forno forno = new Forno(Guid.NewGuid(), new Name("FornoPrincipale"));

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("    BLAISE PASCAL - SMART HOUSE HUB     ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. [Luci]    Gestione Gruppo Salotto");
                Console.WriteLine("2. [Clima]   Controllo Temperatura");
                Console.WriteLine("3. [Safe]    Sicurezza e Ingressi");
                Console.WriteLine("4. [Kitchen] Elettrodomestici Cucina");
                Console.WriteLine("5. [Expert]  Advanced Lamp Controller");
                Console.WriteLine("0. Esci dal sistema");
                Console.WriteLine("----------------------------------------");
                Console.Write("Scegli l'area da gestire: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": MenuLampsRow(salottoGroup); break;
                        case "2": MenuAC(airConditioner); break;
                        case "3": MenuSicurezza(camera, mainDoor); break;
                        case "4": MenuKitchen(fryer, forno); break;
                        case "5": MenuLampController(lampController); break;
                        case "0": running = false; break;
                        default:
                            Console.WriteLine("\n[!] Scelta non valida. Riprova.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRORE]: {ex.Message}");
                    Console.WriteLine("Premi un tasto per tornare al menù principale...");
                    Console.ReadKey();
                }
            }
        }

        // --- SOTTOMENU MIGLIORATI ---

        static void MenuLampsRow(LampsRow row)
        {
            Console.Clear();
            Console.WriteLine("=== [GESTIONE GRUPPO LUCI SALOTTO] ===");
            Console.WriteLine("Comandi disponibili:");
            Console.WriteLine(" [A] Accendi tutte");
            Console.WriteLine(" [B] Spegni tutte");
            Console.WriteLine(" [C] Imposta intensità comune");
            Console.WriteLine(" [0] Torna indietro");
            Console.WriteLine("--------------------------------------");
            Console.Write("Digita il comando: ");

            char op = char.ToLower(Console.ReadKey(true).KeyChar);
            Console.WriteLine(op);

            switch (op)
            {
                case 'a': row.SwitchOn(); Console.WriteLine("-> Gruppo acceso."); break;
                case 'b': row.SwitchOff(); Console.WriteLine("-> Gruppo spento."); break;
                case 'c':
                    Console.Write("Inserisci valore intensità (0-100): ");
                    if (int.TryParse(Console.ReadLine(), out int val)) row.SetIntensityForAllLamps(val);
                    break;
            }
            if (op != '0') Console.ReadKey();
        }

        static void MenuAC(AirConditioner ac)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== [CONTROLLO CLIMATIZZAZIONE] ===");
                Console.WriteLine($"Stato attuale: {ac.temp}°C");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(" [+] Aumenta temp. | [-] Diminuisci temp.");
                Console.WriteLine(" [0] Salva e torna indietro");
                Console.Write("\nComando: ");

                char op = Console.ReadKey(true).KeyChar;
                if (op == '+') ac.increaseTemp();
                else if (op == '-') ac.decreaseTemp();
                else if (op == '0') back = true;
            }
        }

        static void MenuSicurezza(CCTV cctv, Door porta)
        {
            Console.Clear();
            Console.WriteLine("=== [SISTEMA DI SICUREZZA] ===");
            Console.WriteLine($"1. Telecamera Ake:  [{(cctv.IsArmed ? "ARMATA" : "DISARMATA")}]");
            Console.WriteLine($"2. Serratura Porta: [{(porta.isOpen ? "APERTA" : "CHIUSA")}]");
            Console.WriteLine("0. Torna indietro");
            Console.WriteLine("------------------------------");
            Console.Write("Seleziona dispositivo da commutare: ");

            string input = Console.ReadLine();
            if (input == "1") { if (cctv.IsArmed) cctv.Disarm(); else cctv.Arm(); Console.WriteLine("Stato CCTV cambiato."); }
            else if (input == "2") { porta.changeDoorState(); Console.WriteLine("Stato Porta cambiato."); }

            if (input != "0") Console.ReadKey();
        }

        static void MenuKitchen(Fryer fryer, Forno forno)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== [ELETTRODOMESTICI CUCINA] ===");
                // Utilizzo della variabile 'status' come definito nelle tue classi
                Console.WriteLine($"1. Friggitrice  [{(fryer.status ? "ON" : "OFF")}]");
                Console.WriteLine($"2. Forno        [{(forno.status ? "ON" : "OFF")}]");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("a. Accendi/Spegni Friggitrice");
                Console.WriteLine("b. Accendi/Spegni Forno");
                Console.WriteLine("c. Imposta Temperatura Forno");
                Console.WriteLine("0. Torna indietro");
                Console.WriteLine("---------------------------------");
                Console.Write("Scegli un'opzione: ");

                string choice = Console.ReadLine()?.ToLower();

                switch (choice)
                {
                    case "a":
                        if (fryer.status) fryer.TurnOff(); else fryer.TurnOn();
                        Console.WriteLine($"-> Friggitrice ora è {(fryer.status ? "ACCESA" : "SPENTA")}");
                        break;
                    case "b":
                        if (forno.status) forno.TurnOff(); else forno.TurnOn();
                        Console.WriteLine($"-> Forno ora è {(forno.status ? "ACCESO" : "SPENTO")}");
                        break;
                    case "c":
                        Console.Write("Inserisci temperatura forno (°C): ");
                        if (int.TryParse(Console.ReadLine(), out int t))
                        {
                            forno.SetTemperatura(t);
                            Console.WriteLine($"-> Temperatura impostata a {t}°C");
                        }
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }

                if (!back)
                {
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                }
            }
        }

        static void MenuLampController(LampController controller)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== [CQRS ADVANCED LAMP CONTROLLER] ===");
                controller.ShowMenu();
                Console.Write("\nComando Expert (0 per uscire): ");

                string input = Console.ReadLine();
                if (input == "0" || input == "7") { back = true; continue; }

                try
                {
                    switch (input)
                    {
                        case "1": controller.AddLamp(); break;
                        case "2": controller.RemoveLamp(); break;
                        case "3": controller.TurnOnLamp(); break;
                        case "4": controller.TurnOffLamp(); break;
                        case "5": controller.ChangeIntensity(); break;
                        case "6": controller.ListLamps(); break;
                        default: Console.WriteLine("Opzione non riconosciuta."); break;
                    }
                }
                catch (Exception ex) { Console.WriteLine($"\n[ERRORE]: {ex.Message}"); }

                if (!back) { Console.WriteLine("\nPremi un tasto per continuare..."); Console.ReadKey(); }
            }
        }
    }
}
