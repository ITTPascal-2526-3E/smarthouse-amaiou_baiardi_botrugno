using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;
using System.Reflection;
using Color = BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Color;
namespace BlaisePascal.SmartHouse.Domain;

class Program
{
    static void Main(string[] args)
    {
        Guid id = Guid.NewGuid();
        Lamp lamp = new Lamp(35.0, 800, 5000,60);
        lamp.setLampType("led");
        lamp.setEnergyClass("A");
        lamp.TurnOn();
        Console.WriteLine(lamp.IsOn);
        lamp.changeColor("red");
        Console.WriteLine(lamp.Color);
        lamp.setBrightness(70); // Updated to match the correct property name
        Console.WriteLine(lamp.brightness);
        lamp.TurnOff();




        EcoLamp ecoLamp = new EcoLamp(25.0, 600, 5000,60);
        ecoLamp.setLampType("led");
        ecoLamp.setEnergyClass("Aaa");
        ecoLamp.changeColor("blue");
        ecoLamp.TurnOn();
        ecoLamp.turnOffAfterDuration(120);  
        Console.WriteLine(ecoLamp.IsOn);
        Console.WriteLine(ecoLamp.Color);
        Console.WriteLine(ecoLamp.Id);
        Console.WriteLine(ecoLamp.EnergyClass);
        Console.WriteLine(ecoLamp.LampType);
        ecoLamp.TurnOff();



        TwoLampsDevice twoLampDevice = new TwoLampsDevice();
        Lamp lamp2 = new Lamp(35.0, 200, 5000, 60);
        twoLampDevice.setLampAttributes(lamp2);
        twoLampDevice.setLampType("led");
        twoLampDevice.setEnergyClass("B");
        twoLampDevice.turnOn();
        twoLampDevice.turnOff();
        twoLampDevice.changeColor("green");
        twoLampDevice.setBrightness(50);
        Console.WriteLine("Lampada 1 - Stato acceso: " + lamp2.IsOn);
        Console.WriteLine("Lampada 1 - Colore: " + lamp2.Color);
        Console.WriteLine("Lampada 1 - Luminosità: " + lamp2.brightness);
        EcoLamp ecoLamp2 = new EcoLamp(20.0, 400, 5000, 60);
        twoLampDevice.setEcoLampAttributes(ecoLamp2);
        twoLampDevice.setEcoLampType("led");
        twoLampDevice.setEcoLampEnergyClass("Aaa");
        twoLampDevice.ecoLampTurnOn();
        twoLampDevice.ecoLampTurnOff();
        twoLampDevice.ecoLampChangeColor("yellow");
        twoLampDevice.ecoLampSetBrightness(80);
        twoLampDevice.turnOffAfterDuration(90);
        Console.WriteLine("Lampada 2 - Stato acceso: " + ecoLamp2.IsOn);
        Console.WriteLine("Lampada 2 - Colore: " + ecoLamp2.Color);
        Console.WriteLine("Lampada 2 - Luminosità: " + ecoLamp2.brightness);
        Console.WriteLine(ecoLamp2.DurationBeforeOff);






        AirConditioner airConditioner = new AirConditioner(18.00);
        airConditioner.setName("Samsung WindFree");
        airConditioner.TurnOn();
        Console.WriteLine("AC acceso: " + airConditioner.status);
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
        thermostat.setName("Airconditioner");
        Console.WriteLine(thermostat.Id);

        Door door = new Door(true, "acciaio", "inox", true, false, false, 10.0, 5.0, 4.0);
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


        CCTV cctv = new CCTV(200, 400, 60, 128, false, false);
        cctv.TurnOn();
        Console.WriteLine("CCTV è accesa " + cctv.status);
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
        cctv.change_bulletProof();
        Console.WriteLine("CCTV antiproiettile cambiata: ");


        Fryer fryer = new Fryer(180.00, 7, "olio");
        fryer.TurnOn();
        Console.WriteLine("Stato friggitrice cambiato " + fryer.status);
        fryer.changeBasketStatus();
        Console.WriteLine("Stato cestello friggitrice cambiato: ");
        fryer.changeTemp(180.0);
        Console.WriteLine("Temperatura friggitrice cambiata: ");
        fryer.change_NumberOfFryer_BeforeChangeOil(5);
        Console.WriteLine("Numero di fritture prima di cambiare l'olio cambiato: ");
        Console.WriteLine("ID Friggitrice: " + fryer.Id);





    }
}