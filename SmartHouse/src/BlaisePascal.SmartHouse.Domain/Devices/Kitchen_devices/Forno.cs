using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Devices.Kitchen_devices
{
    public class Forno : Iswitchable   
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public int Temperatura { get; private set; }
        public ModalitaForno Modalita { get; private set; }
        public bool status { get; private set; }
        public TimeSpan DurataTimer { get; private set; }
        public DateTime? FineTimer { get; private set; }

        public Forno(Guid id, Name nome)
        {
            this.Id = id;
            this.Name = nome;
            this.Temperatura = 0;
            this.status = false;
            this.Modalita = ModalitaForno.Statico;
            this.DurataTimer = TimeSpan.Zero;
            this.FineTimer = null;
        }
        public void TurnOn()
        {
            status = true;
        }
        public void TurnOff() {
            status = false;
            DurataTimer = TimeSpan.Zero;
            FineTimer = null;
        }
        public void SetTemperatura(int temperatura)
        {
            if (status != true)
                throw new InvalidOperationException("Il forno deve essere acceso.");

            if (temperatura < 0 || temperatura > 300)
                throw new ArgumentOutOfRangeException(nameof(temperatura), "La temperatura deve essere compresa tra 0 e 300 gradi.");
            Temperatura = temperatura;
        }
        public void SetModalita(ModalitaForno modalita)
        {
            if (status != true)
                throw new InvalidOperationException("Il forno deve essere acceso.");
            Modalita = modalita;
        }
        public void SetTimer(TimeSpan durata)
        {
            if (status != true)
                throw new InvalidOperationException("Il forno deve essere acceso.");
            if (durata <= TimeSpan.Zero || durata > TimeSpan.FromHours(8))
                throw new ArgumentOutOfRangeException(nameof(durata), "La durata del timer deve essere compresa tra 1 minuto e 8 ore.");
            DurataTimer = durata;
            FineTimer = DateTime.Now.Add(durata);
        }
        public void ControlTimer()
        {
            if (FineTimer.HasValue && DateTime.Now >= FineTimer.Value)
            {
                status = false;
            }
        }
    }
}
