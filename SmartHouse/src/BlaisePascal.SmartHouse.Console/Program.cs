using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;
using System.Reflection;
using Color = BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Color;
using System;
using BlaisePascal.SmartHouse;
namespace BlaisePascal.SmartHouse.Domain { }


class Program
{
    static void Main(string[] args)
    {
        // Inizializzazione del sistema completo
        LampsRow salottoLamps = new LampsRow();
        salottoLamps.AddLamp(new Lamp(35.0, 800, 5000, 60, "pir"));
        salottoLamps.AddLamp(new EcoLamp(20.0, 400, 5000, 60, "vitto"));

        AirConditioner ac = new AirConditioner(22.0);
        CCTV telecamera = new CCTV();
        Door portaIngresso = new Door(false, "acciaio", true, false, 10.0, 5.0, 4.0);

        bool continua = true;

        while (continua)
        {
            Console.Clear(); // Pulisce la console per un menu più ordinato
            Console.WriteLine("=== SMART HOME CONTROL PANEL ===");
            Console.WriteLine("1.  Gestisci Gruppo Luci (LampsRow)");
            Console.WriteLine("2.  Gestisci Condizionatore");
            Console.WriteLine("3.  Gestisci Sicurezza (CCTV & Porta)");
            Console.WriteLine("0.  Esci dal sistema");
            Console.Write("\nSeleziona un'opzione: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    MenuLampsRow(salottoLamps);
                    break;
                case "2":
                    MenuAC(ac);
                    break;
                case "3":
                    MenuSicurezza(telecamera, portaIngresso);
                    break;
                case "0":
                    continua = false;
                    Console.WriteLine("Chiusura del pannello di controllo...");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Premi un tasto per riprovare.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // --- SOTTOMENU LAMPSROW (Gruppo di luci) ---
    static void MenuLampsRow(LampsRow row)
    {
        Console.WriteLine("\n[MENU GRUPPO LUCI SALOTTO]");
        Console.WriteLine("a. Accendi tutte le luci");
        Console.WriteLine("b. Spegni tutte le luci");
        Console.WriteLine("c. Imposta intensità per tutte (0-100)");

        char op = Console.ReadKey(true).KeyChar;
        switch (op)
        {
            case 'a':
                row.SwitchOn();
                Console.WriteLine("Tutte le luci sono state ACCESE.");
                break;
            case 'b':
                row.SwitchOff();
                Console.WriteLine("Tutte le luci sono state SPENTE.");
                break;
            case 'c':
                Console.Write("\nInserisci intensità (0-100): ");
                if (int.TryParse(Console.ReadLine(), out int lum))
                {
                    row.SetIntensityForAllLamps(lum);
                    Console.WriteLine($"Intensità impostata a {lum} per tutte le lampade.");
                }
                break;
        }
        Console.WriteLine("Premi un tasto per tornare al menu principale...");
        Console.ReadKey();
    }

    // --- SOTTOMENU CONDIZIONATORE ---
    static void MenuAC(AirConditioner ac)
    {
        Console.WriteLine("\n[MENU CONDIZIONATORE]");
        Console.WriteLine("+. Aumenta Temperatura");
        Console.WriteLine("-. Diminuisci Temperatura");

        char op = Console.ReadKey(true).KeyChar;
        switch (op)
        {
            case '+':
                ac.increaseTemp();
                Console.WriteLine($"Temperatura attuale: {ac.temp}°C");
                break;
            case '-':
                ac.decreaseTemp();
                Console.WriteLine($"Temperatura attuale: {ac.temp}°C");
                break;
        }
        Console.WriteLine("Premi un tasto per tornare al menu principale...");
        Console.ReadKey();
    }

    // --- SOTTOMENU SICUREZZA ---
    static void MenuSicurezza(CCTV cctv, Door porta)
    {
        Console.WriteLine("\n[MENU SICUREZZA]");
        Console.WriteLine("1. Arma/Disarma Telecamere");
        Console.WriteLine("2. Apri/Chiudi Porta d'ingresso");

        char op = Console.ReadKey(true).KeyChar;
        switch (op)
        {
            case '1':
                if (cctv.IsArmed) cctv.Disarm(); else cctv.Arm();
                Console.WriteLine($"Stato CCTV: {(cctv.IsArmed ? "ARMATA" : "DISARMATA")}");
                break;
            case '2':
                porta.changeDoorState();
                Console.WriteLine("Stato della porta cambiato.");
                break;
        }
        Console.WriteLine("Premi un tasto per tornare al menu principale...");
        Console.ReadKey();
    }
}