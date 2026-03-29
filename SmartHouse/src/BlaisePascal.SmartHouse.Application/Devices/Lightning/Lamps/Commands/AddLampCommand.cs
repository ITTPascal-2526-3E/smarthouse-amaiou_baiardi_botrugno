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
        public AddLampCommand(ILampRepository lampRepository) => _lampRepository = lampRepository;

        // Accetta il Value Object Name come nel controller
        public void Execute(Name name)
        {
            var lamp = new Lamp(30, 50, 35, 25, name);
            _lampRepository.AddLamp(lamp);
        }
    }
}
