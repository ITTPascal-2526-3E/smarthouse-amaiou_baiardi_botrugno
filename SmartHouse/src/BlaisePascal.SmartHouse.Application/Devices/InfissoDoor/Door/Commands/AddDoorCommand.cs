using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories;
using System.Net.Http.Headers;

namespace BlaisePascal.SmartHouse.Application
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        Name="doorRepository"
        public AddDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }
        public void Execute(string name, string imageUrl)
        {
            var door = new Door(new Name(name));
            _doorRepository.Add(door);
        }
    }
}