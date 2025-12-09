using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;
using Color = BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Color;
namespace BlaisePascal.SmartHouse.Domain;

class Program
{
    static void Main(string[] args)
    {
        Lamp lamp = new Lamp();
        lamp.isOn = true;
        lamp.lampTypeProperty("led"); // Updated to match the correct property name
        lamp.brightness = 80; // Updated to match the correct property name


        Console.WriteLine(value: $"Lamp is on: {lamp.isOn}");
        Console.WriteLine($"Lamp brightness: {lamp.brightness}"); // Updated to match the correct property name
        Console.WriteLine("Lamp ID: " + lamp.Id);
        Console.WriteLine("Accesa: " + lamp.isOn);
        Console.WriteLine("Tipo: " + lamp.lampType);
        Console.WriteLine("Luminosità: " + lamp.brightnessProperty);
        Console.WriteLine("Colore: " + lamp.color);


        EcoLamp ecoLamp = new EcoLamp();
        ecoLamp.turnOffAfterDuration(120);
        Console.WriteLine("EcoLamp spegnimento dopo durata impostata.");
        ecoLamp.setEnergyClass("A+++");
        Console.WriteLine("Classe energetica EcoLamp impostata.");
        ecoLamp.setBrightness(ecoLamp.brightnessProperty);
        Console.WriteLine("Luminosità EcoLamp impostata.");
        ecoLamp.setName("EcoBright 3000");
        Console.WriteLine("Nome EcoLamp impostato: " + ecoLamp.name);
        // Update the following line to pass a string representation of the Color enum value
        ecoLamp.setColor(Color.red.ToString());
        Console.WriteLine("Colore EcoLamp impostato: " + ecoLamp.color);




        AirConditioner airConditioner = new AirConditioner();
        airConditioner.setName("Samsung WindFree");
        airConditioner.turnOn();
        Console.WriteLine("AC acceso: " + airConditioner.isOn);
        airConditioner.temp = 20.0;
        Console.WriteLine("Temperatura iniziale: " + airConditioner.temp);
        airConditioner.increaseTemp();
        Console.WriteLine(airConditioner.temp);
        airConditioner.decreaseTemp();
        Console.WriteLine("Temperatura dopo aumento: " + airConditioner.temp);
        airConditioner.PutInEnergySavingMode();
        Console.WriteLine(airConditioner.energySavingMode);
        airConditioner.changefunspeed();
        Console.WriteLine("Velocità ventola cambiata.");



        Thermostat thermostat = new Thermostat();
        thermostat.turnOnAirConditioner();
        Console.WriteLine("AC acceso tramite termostato.");
        thermostat.turnOffAirConditioner();
        Console.WriteLine("AC spento tramite termostato.");
        thermostat.changeAirConditionerMode();
        Console.WriteLine("Modalità risparmio energetico attivata tramite termostato.");
        thermostat.changeAirConditionerFunSpeed();
        Console.WriteLine("Velocità ventola cambiata tramite termostato.");
        thermostat.increaseAirConditionerTemp();
        Console.WriteLine("Temperatura aumentata tramite termostato.");
        thermostat.decreaseAirConditionerTemp();
        Console.WriteLine("Temperatura diminuita tramite termostato.");
        thermostat.setName();
        Console.WriteLine(thermostat.Id);

        Door door = new Door();
        door.changeDoorState();
        Console.WriteLine("Stato porta cambiato: ");
        door.changeLength(6.00);
        Console.WriteLine("Lunghezza porta cambiata: ");
        door.changeHeight(2.50);
        Console.WriteLine("Altezza porta cambiata: ");
        door.changeWidth(0.90);
        Console.WriteLine("Larghezza porta cambiata: ");
        door.change_BulletProof();
        Console.WriteLine("Porta antiproiettile cambiata: ");
        door.change_EnterHouseDoor();
        Console.WriteLine("Porta d'ingresso cambiata: ");
        door.change_InsideHouseDoor();
        Console.WriteLine("Porta interna cambiata: ");


        CCTV cctv = new CCTV();
        cctv.changeStatus();
        Console.WriteLine("Stato CCTV cambiato: ");
        cctv.change_nightVision();
        Console.WriteLine("Visione notturna CCTV cambiata: ");
        cctv.change_bulletProof();
        Console.WriteLine("CCTV antiproiettile cambiata: ");
        cctv.change_storageCapacity(200);
        Console.WriteLine("Capacità di archiviazione CCTV cambiata: ");
        cctv.changeWidth(1920);
        Console.WriteLine("Larghezza risoluzione CCTV cambiata: ");
        cctv.changeHeight(1080);
        Console.WriteLine("Altezza risoluzione CCTV cambiata: ");


        Fryer fryer = new Fryer();
        fryer.changeStatus();
        Console.WriteLine("Stato friggitrice cambiato: ");
        fryer.changeBasketStatus();
        Console.WriteLine("Stato cestello friggitrice cambiato: ");
        fryer.changeTemp(180.0);
        Console.WriteLine("Temperatura friggitrice cambiata: ");
        fryer.change_NumberOfFryer_BeforeChangeOil(5);
        Console.WriteLine("Numero di fritture prima di cambiare l'olio cambiato: ");
        fryer.typeProperty = "olio";
        Console.WriteLine("Tipo di friggitrice cambiato: " + fryer.typeProperty);
        Console.WriteLine("ID Friggitrice: " + fryer.Id);





    }
}