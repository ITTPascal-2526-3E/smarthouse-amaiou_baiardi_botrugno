using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console
{
    internal class LampsRow
    {
        private List<Lamp> lamps = new List<Lamp>();

        public void SwitchOn()
        {
            lamps.ForEach(l => l.TurnOn());
        }
        public void SwitchOn(Guid id)
        {
            lamps.FirstOrDefault(l => l.Id == id)?.TurnOn();
        }
        public void SwitchOn(string name)
        {
            lamps.FirstOrDefault(l => l.Name == name)?.TurnOn();
        }
        public void SwitchOff()
        {
            lamps.ForEach(l => l.TurnOff());
        }
        public void SwitchOff(Guid id)
        {
            lamps.FirstOrDefault(l => l.Id == id)?.TurnOff();
        }
        public void SwitchOff(string name)
        {
            lamps.FirstOrDefault(l => l.Name == name)?.TurnOff();
        }
        public void AddLamp(Lamp lamp)
        {
            lamps.Add(lamp);
        }
        public void AddLampInPosition(Lamp lamp, int position)
        {
            if (position < 0 || position > lamps.Count)
                throw new ArgumentOutOfRangeException(nameof(position));

            lamps.Insert(position, lamp);
        }
        public void RemoveLamp(Guid id)
        {
            lamps.RemoveAll(l => l.Id == id);
        }

        public void RemoveLamp(string name)
        {
            lamps.RemoveAll(l => l.Name == name);
        }
        public void RemoveLampInPosition(int position)
        {
            if (position < 0 || position >= lamps.Count)
                throw new ArgumentOutOfRangeException(nameof(position));

            lamps.RemoveAt(position);
        }
        public void SetIntensityForAllLamps(int intensity)
        {
            lamps.ForEach(l => l.setBrightness(intensity));
        }
        public void SetIntensityForLamp(Guid id, int intensity)
        {
            lamps.FirstOrDefault(l => l.Id == id)?.setBrightness(intensity);
        }
        public void SetIntensityForLamp(string name, int intensity)
        {
            lamps.FirstOrDefault(l => l.Name == name)?.setBrightness(intensity);
        }
        public Lamp FindLampWithMaxIntensity()
        {
            return lamps.OrderByDescending(l => l.brightness).FirstOrDefault();
        }
        public Lamp FindLampWithMinIntensity()
        {
            return lamps.OrderBy(l => l.brightness).FirstOrDefault();
        }
        public List<Lamp> FindLampsByIntensityRange(int min, int max)
        {
            return lamps
                .Where(l => l.brightness >= min && l.brightness <= max)
                .ToList();
        }
    }
}
