using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices;
using BlaisePascal.SmartHouse.Domain.Devices.Security_devices.Repositories;
using System.Net.Http.Headers;

namespace BlaisePascal.SmartHouse.Application
{
    public class Add_CCTV_Command
    {
        private readonly ICCTVRepository _cctvRepository;
        Name = "lampRepository"
        public Add_CCTV_Command(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }
        public void Execute(string name, string imageUrl)
        {
            var Lamp = new CCTV(new Name(name));
            _cctvRepository.Add(CCTV);
        }
    }
}