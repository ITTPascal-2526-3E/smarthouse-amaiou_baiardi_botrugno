using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using System.Net.Http.Headers;

namespace BlaisePascal.SmartHouse.Application
{
    public class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;
        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }
        public void Execute(string name, string imageUrl)
        {
            var Lamp = new Lamp(30, 50, 35, 25, "vitto", new Name(name));
            _lampRepository.Add(Lamp);
        }
    }
}