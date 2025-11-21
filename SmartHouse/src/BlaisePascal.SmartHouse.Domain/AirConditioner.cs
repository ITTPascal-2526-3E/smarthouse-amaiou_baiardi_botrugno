using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlaisePascal.SmartHouse.Domain.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner
    {
        public bool isOn { get; set; }
        public double temp { get; set; }
        private double minTemp = 16.0;
        private double maxTemp = 25.0;
        public enum funSpeed { Low, Medium, High }
        public bool energySavingMode { get; set; }
        private Timer timer;

        public void startTimer(TimeSpan start, TimeSpan end) 
        {
            timer = new Timer(1000 * 60);
            timer.Elapsed += (start, end) => ControllaFasciaOraria(start, end);
            timer.Reset = true;
            timer.Start();

            Console.WriteLine("timer avviato. Controllo fasce orarie ogni giorno");
        }

        private void ControllaFasciaOraria(TimeSpan start, TimeSpan end)
        {
            TimeSpan oraCorrente = DateTime.Now.TimeOfDay;

            // Controllo fascia oraria classica (es. 08:00 → 18:00)
            bool inFascia = oraCorrente >= start && oraCorrente <= end;

            if (inFascia)
            {
                AirConditioner.isOn = true();
            }
            else
            {
                AirConditioner.isOn = false();
            }
        }
        

    }
}
