using BlaisePascal.SmartHouse;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Temp_devices;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
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

        Thermostat thermostat = new Thermostat();
        thermostat.turnOnAirConditioner();
        AirConditioner airConditioner = new AirConditioner();
        Console.WriteLine(airConditioner.isOn);
    }
}