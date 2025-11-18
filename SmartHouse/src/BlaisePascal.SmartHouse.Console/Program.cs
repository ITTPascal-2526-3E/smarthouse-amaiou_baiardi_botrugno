using BlaisePascal.SmartHouse;
using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.LampType;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Lamp lamp = new Lamp();
        lamp.isOn = true;
        lamp.lampTypeProperty = LampType.led;
        lamp.brightnessProperty = 80;
        
        Console.WriteLine($"Lamp is on: {lamp.isOn}");
        Console.WriteLine($"Lamp brightness: {lamp.brightnessProperty}");

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