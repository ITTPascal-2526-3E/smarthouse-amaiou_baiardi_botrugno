using BlaisePascal.SmartHouse;
using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.LampType;
using System.Drawing;
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

        CCTV cctv = new CCTV();
        cctv.isOn = true;
        cctv.ResolutionWidth = 1920;
        cctv.ResolutionHeight = 1080;
        cctv.FrameRate = 30;
        cctv.StorageCapacity = 256;
        cctv.NightVision = true;
        cctv.BulletProof = false;
    }
}