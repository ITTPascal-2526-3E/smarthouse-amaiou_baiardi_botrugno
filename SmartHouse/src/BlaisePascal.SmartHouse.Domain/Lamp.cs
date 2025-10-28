namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        private bool isOn;
        public int consumptions { get; set; }
        public string lampType { get; set; }
        public double lampHeat { get; set; }
        public string energyClass { get; set; }
        public int brightness { get; set; }
        public int lumen { get; set; }

    }
}