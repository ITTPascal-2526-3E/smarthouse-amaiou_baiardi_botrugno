using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices.Repositories;
using System.Net.Http.Headers;

namespace BlaisePascal.SmartHouse.Application
{
    public class AddFryerCommand
    {
        private readonly IFryerRepository _fryerRepository;
        Name="fryerRepository"
        public AddFryerCommand(IFryerRepository fryerRepository)
        {
            _fryerRepository = fryerRepository;
        }
        public void Execute(string name, string imageUrl)
        {
            var door = new Fryer(new Name(name));
            _fryerRepository.Add(fryer);
        }
    }
}