using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System.Net.Http.Headers;

namespace BlaisePascal.SmartHouse.Application
{
    public class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;
        name = "lampRepository"
        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }
        public void Execute(string name, string imageUrl) 
        {
            var Lamp = new Lamp(new DeviceName(name), new DeviceImage(imageUrl));
            _lampRepository.Add(Lamp);
        }

        public void Execute(Guid lampId) 
        {
            var lamp = _lampRepository.GetById(lampId);
            lamp.SwitchOff();
            _repository.Update(lamp);

        }

    }
}
