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
        Guid id = Guid.NewGuid();
        Lamp lamp = new Lamp(35.0, 800, 5000, 60, "pir");
        lamp.setLampType("led");
        lamp.setEnergyClass("A");
        lamp.TurnOn();
        Console.WriteLine(lamp.status);
        lamp.changeColor("red");
        Console.WriteLine(lamp.color);
        lamp.setBrightness(70); // Updated to match the correct property name
        Console.WriteLine(lamp.brightness);
        lamp.TurnOff();




        EcoLamp ecoLamp = new EcoLamp(25.0, 600, 5000, 60, "vitto");
        ecoLamp.setLampType("led");
        ecoLamp.setEnergyClass("Aaa");
        ecoLamp.changeColor("blue");
        ecoLamp.TurnOn();
        ecoLamp.turnOffAfterDuration(120);
        Console.WriteLine(ecoLamp.status);
        Console.WriteLine(ecoLamp.color);
        Console.WriteLine(ecoLamp.Id);
        Console.WriteLine(ecoLamp.EnergyClass);
        Console.WriteLine(ecoLamp.LampType);
        ecoLamp.TurnOff();



        TwoLampsDevice twoLampDevice = new TwoLampsDevice();
        Lamp lamp2 = new Lamp(35.0, 200, 5000, 60, "pira");
        twoLampDevice.setLampAttributes(lamp2);
        twoLampDevice.setLampType("led");
        twoLampDevice.setEnergyClass("B");
        twoLampDevice.turnOn();
        twoLampDevice.turnOff();
        twoLampDevice.changeColor("green");
        twoLampDevice.setBrightness(50);
        Console.WriteLine("Lampada 1 - Stato acceso: " + lamp2.status);
        Console.WriteLine("Lampada 1 - Colore: " + lamp2.color);
        Console.WriteLine("Lampada 1 - Luminosità: " + lamp2.brightness);
        EcoLamp ecoLamp2 = new EcoLamp(20.0, 400, 5000, 60, "vitto");
        twoLampDevice.setEcoLampAttributes(ecoLamp2);
        twoLampDevice.setEcoLampType("led");
        twoLampDevice.setEcoLampEnergyClass("Aaa");
        twoLampDevice.ecoLampTurnOn();
        twoLampDevice.ecoLampTurnOff();
        twoLampDevice.ecoLampChangeColor("yellow");
        twoLampDevice.ecoLampSetBrightness(80);
        twoLampDevice.turnOffAfterDuration(90);
        Console.WriteLine("Lampada 2 - Stato acceso: " + ecoLamp2.status);
        Console.WriteLine("Lampada 2 - Colore: " + ecoLamp2.color);
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

        Door door = new Door(true, "acciaio", true, false, 10.0, 5.0, 4.0);
        door.changeDoorState();
        Console.WriteLine("Stato porta cambiato: ");
        Console.WriteLine("Porta antiproiettile cambiata: ");
        door.change_EnterHouseDoor();
        Console.WriteLine("Porta d'ingresso cambiata: ");
        door.change_InsideHouseDoor();
        Console.WriteLine("Porta interna cambiata: ");


        CCTV cctv = new CCTV();
        cctv.TurnOn();
        Console.WriteLine("CCTV è accesa " + cctv.IsOn);
        cctv.TurnOff();
        Console.WriteLine("CCTV è spenta " + cctv.IsOn);
        cctv.Arm();
        Console.WriteLine("CCTV è armata" + cctv.IsArmed);
        cctv.Disarm();
        Console.WriteLine("CCTV è disarmata" + cctv.IsArmed);


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


        LampsRow lampsRow = new LampsRow();
        lampsRow.AddLamp(new Lamp(30.0, 500, 5000, 60, "led"));
        lampsRow.AddLamp(new EcoLamp(20.0, 400, 5000, 60, "vitto"));
        Lamp newLamp = new Lamp(35.0, 800, 5000, 60, "pir");
        lampsRow.SwitchOn();
        Console.WriteLine("Tutte le lampade sono accese: ");
        lampsRow.SwitchOn(newLamp.Id); // Non esiste, solo per dimostrazione
        lampsRow.SwitchOn("hhh");
        Console.WriteLine("la lampada con name hhh è accesa: ");
        lampsRow.SwitchOff();
        Console.WriteLine("Tutte le lampade sono spente: ");
        lampsRow.SwitchOff(newLamp.Id);
        Console.WriteLine("La lampada con guid: Guid è stata spenta ");
        lampsRow.SwitchOff("hhh");
        Console.WriteLine("la lampada con name hhh è spenta: ");
        lampsRow.AddLampInPosition(newLamp, 1);
        Console.WriteLine("Lampada aggiunta in posizione 1: ");
        lampsRow.RemoveLamp(newLamp.Id);
        Console.WriteLine("Lampada rimossa con guid specificato: ");
        lampsRow.RemoveLamp("zzz");
        Console.WriteLine("Lampada rimossa con name specificato: ");
        lampsRow.RemoveLampInPosition(0);
        Console.WriteLine("Lampada rimossa in posizione 0: ");
        lampsRow.SetIntensityForAllLamps(35);
        Console.WriteLine("Intensità impostata a 35 per tutte le lampade: ");
        lampsRow.SetIntensityForLamp(newLamp.Id, 50);
        Console.WriteLine("Intensità impostata a 50 per la lampada con guid specificato: ");
        lampsRow.SetIntensityForLamp("hhh", 75);
        Console.WriteLine("Intensità impostata a 75 per la lampada con name specificato: ");
        lampsRow.FindLampWithMaxIntensity();
        Console.WriteLine("Lampada con intensità massima trovata: ");
        lampsRow.FindLampWithMinIntensity();
        Console.WriteLine("Lampada con intensità minima trovata: ");
        lampsRow.setEnergyClass(newLamp.Id, "A");
        Console.WriteLine("Classe energetica impostata per la lampada con guid specificato: ");
        lampsRow.setLampType(newLamp.Id, "led");
        Console.WriteLine("Tipo di lampada impostato per la lampada con guid specificato: ");
        lampsRow.changeColor(newLamp.Id, "white");
        Console.WriteLine("Colore cambiato per la lampada con guid specificato: ");

    }
}