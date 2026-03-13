using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;
using System.Reflection;
using Color = BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Color;
using System;
using BlaisePascal.SmartHouse;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
namespace BlaisePascal.SmartHouse.Domain { }


class Program
{
    static void Main(string[] args)
    {
        // Inizializzazione del sistema completo
        LampsRow salottoLamps = new LampsRow();
        salottoLamps.AddLamp(new Lamp(35.0, 800, 5000, 60, new Name("Botru")));
        salottoLamps.AddLamp(new EcoLamp(20.0, 400, 5000, 60, new Name("Vitto")));

        AirConditioner ac = new AirConditioner(22.0);
        CCTV telecamera = new CCTV(new Name("Ake"));
        Door portaIngresso = new Door(false, "Acciaio", true, false, 10.0, 5.0, 4.0, new Name("Vitto"));

        // Friggitrice (kitchen device) di esempio
        Fryer fryer = new Fryer(180.0, 5, "olio", new Name("FriggitriceCucina"));
        Forno forno = new Forno(Guid.NewGuid(), new Name("FornoCucina"));

        bool continua = true;

        while (continua)
        {
            Console.Clear(); // Pulisce la console per un menu più ordinato
            Console.WriteLine("=== SMART HOME CONTROL PANEL ===");
            Console.WriteLine("1.  Gestisci Gruppo Luci (LampsRow)");
            Console.WriteLine("2.  Gestisci Condizionatore");
            Console.WriteLine("3.  Gestisci Sicurezza (CCTV & Porta)");
            Console.WriteLine("4.  Gestisci Kitchen Devices");
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
                case "4":
                    MenuKitchen(fryer, forno);
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

    // ---- SOTTOMENU GESTIONE KITCHEN DEVICES (es. Fryer) ----
    static void MenuKitchen(Fryer fryer, Forno forno)
    {
        Console.WriteLine("\n[MENU KITCHEN DEVICES]");
        Console.WriteLine("FRIGGITRICE");
        Console.WriteLine("a. Accendi friggitrice");
        Console.WriteLine("b. Spegni friggitrice");
        Console.WriteLine("c. Cambia stato cestello (up/down)");
        Console.WriteLine("d. Imposta temperatura friggitrice");
        Console.WriteLine("e. Imposta numero fritture prima cambio olio");

        Console.WriteLine("\nFORNO");
        Console.WriteLine("f. Accendi forno");
        Console.WriteLine("g. Spegni forno");
        Console.WriteLine("h. Imposta temperatura forno");
        Console.WriteLine("i. Cambia modalità forno");
        Console.WriteLine("l. Imposta timer forno");

        Console.WriteLine("\n0. Torna al menu principale");

        char op = Console.ReadKey(true).KeyChar;

        switch (op)
        {
            // -------- FRYER --------

            case 'a':
                try
                {
                    fryer.TurnOn();
                    Console.WriteLine("Friggitrice accesa.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }
                break;

            case 'b':
                try
                {
                    fryer.TurnOff();
                    Console.WriteLine("Friggitrice spenta.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }
                break;

            case 'c':
                fryer.changeBasketStatus();
                Console.WriteLine($"Stato cestello: {fryer.basketStatus}");
                break;

            case 'd':
                Console.Write("\nInserisci temperatura friggitrice: ");
                if (double.TryParse(Console.ReadLine(), out double temp))
                {
                    try
                    {
                        fryer.changeTemp(temp);
                        Console.WriteLine($"Temperatura impostata a {fryer.temperature}°C");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Valore temperatura non valido.");
                }
                break;

            case 'e':
                Console.Write("\nInserisci numero fritture prima cambio olio: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    try
                    {
                        fryer.change_NumberOfFryer_BeforeChangeOil(n);
                        Console.WriteLine($"Numero impostato a {fryer.numberOfFryerBeforeChangeOil}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Valore non valido.");
                }
                break;

            // -------- FORNO --------

            case 'f':
                try
                {
                    forno.TurnOn();
                    Console.WriteLine("Forno acceso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }
                break;

            case 'g':
                try
                {
                    forno.TurnOff();
                    Console.WriteLine("Forno spento.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }
                break;

            case 'h':
                Console.Write("\nInserisci temperatura forno: ");
                if (int.TryParse(Console.ReadLine(), out int tempForno))
                {
                    try
                    {
                        forno.SetTemperatura(tempForno);
                        Console.WriteLine($"Temperatura forno impostata a {tempForno}°C");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Valore temperatura non valido.");
                }
                break;

            case 'i':
                Console.WriteLine("\nSeleziona modalità forno:");
                Console.WriteLine("1. Statico");
                Console.WriteLine("2. Ventilato");
                Console.WriteLine("3. Grill");
                Console.WriteLine("4. Scongelamento");
                Console.WriteLine("5. Pizza");

                if (int.TryParse(Console.ReadLine(), out int scelta))
                {
                    try
                    {
                        ModalitaForno modalita = (ModalitaForno)(scelta - 1);
                        forno.SetModalita(modalita);
                        Console.WriteLine($"Modalità impostata: {modalita}");
                    }
                    catch
                    {
                        Console.WriteLine("Modalità non valida.");
                    }
                }
                break;

            case 'l':
                Console.Write("\nInserisci durata timer in minuti: ");
                if (int.TryParse(Console.ReadLine(), out int minuti))
                {
                    try
                    {
                        forno.SetTimer(TimeSpan.FromMinutes(minuti));
                        Console.WriteLine($"Timer impostato a {minuti} minuti.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Valore non valido.");
                }
                break;

            case '0':
                return;

            default:
                Console.WriteLine("Scelta non valida.");
                break;
        }

        Console.WriteLine("Premi un tasto per tornare al menu principale...");
        Console.ReadKey();
    }
}