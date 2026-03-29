using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightining.Lamps
{
    public class CsvLampRepository
    {
        private readonly string _filePath = "lamps.csv";

        public CsvLampRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();
            var dataFolder = Path.Combine(solutionRoot, "Data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "lamps.csv");
            if (!File.Exists(_filePath))
            {
                Save(new List<Lamp>());
            }
        }

        public List<Lamp> GetAll()
        {
            return Load();
        }

        public Lamp GetById(Guid id)
        {
            return Load().First(l => l.Id == id);
        }

        private void Save(List<Lamp> lamps)
        {
            var dtos = lamps;
            var lines = new List<string>
            {
                "Id,Name,Color,Brightness,IsOn,ligthOnspecificTime,ligthOffSpecificTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.getName(),
                    dto.getColor(),
                    dto.brightness,
                    dto.status,
                    0,
                    0));
            }

            File.WriteAllLines(_filePath, lines);
        }

        private List<Lamp> Load()
        {
            if (!File.Exists(_filePath))
                return new List<Lamp>();

            var lines = File.ReadAllLines(_filePath);
            var lamps = new List<Lamp>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');
                if (parts.Length < 5)
                    continue;

                Guid id;
                Guid.TryParse(parts[0], out id);

                var name = new Name(parts[1] ?? string.Empty);

                if (!Enum.TryParse<Color>(parts[2], true, out var color))
                    color = Color.white;

                if (!int.TryParse(parts[3], out var brightness))
                    brightness = 0;

                if (!bool.TryParse(parts[4], out var isOn))
                    isOn = false;

                // Build Lamp using the defined constructor:
                // Lamp(double lampHeat, int lumen, int durationBeforeItFlashes, int Initialbrightness, Name name)
                // CSV does not contain lampHeat/lumen/duration, use sensible defaults and apply parsed brightness/name afterwards.
                var lamp = new Lamp(0.0 /*lampHeat*/, 0 /*lumen*/, 0 /*durationBeforeItFlashes*/, brightness, name);

                lamp.Id = id;
                lamp.color = color;
                lamp.brightness = brightness;
                lamp.status = isOn;

                lamps.Add(lamp);
            }
            return lamps;
        }

        public void Update(Lamp lamp)
        {
            var lamps = Load();
            var index = lamps.FindIndex(l => l.Id == lamp.Id);
            if (index >= 0)
            {
                lamps[index] = lamp;
                Save(lamps);
            }
        }

        public void Add(Lamp lamp)
        {
            var lamps = Load();
            lamps.Add(lamp);
            Save(lamps);
        }


        public void Remove(Lamp lamp)
        {
            var lamps = Load();
            lamps.RemoveAll(l => l.Id == lamp.Id);
            Save(lamps);
        }
    }
}
