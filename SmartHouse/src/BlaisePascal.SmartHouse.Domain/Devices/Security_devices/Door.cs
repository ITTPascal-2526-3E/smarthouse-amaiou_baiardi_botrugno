using BlaisePascal.SmartHouse.Domain.Devices.Luminous_devices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public sealed class Door : Isecurity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool isOpen { get; set; }
        public string material { get; set; }
        public EnumType type {get; protected set;}
        public bool isEnterHouseDoor { get; set; }
        public bool isInsideHouseDoor { get; set; }
        public double height, length, width;

        // aggiungere funzioni in modo da poter cambiare lo stato della porta (aperta/chiusa), la lunghezza, se è antiproiettile, se è porta d'ingresso o porta interna ecc 
        public Door(bool IsOpen, string Material, bool IsEnterHouseDoor, bool IsInsideHouseDoor, double Height, double Length, double Width)
        {
            Id = Guid.NewGuid();
            isOpen = IsOpen;
            this.material = Material;
            this.isEnterHouseDoor = IsEnterHouseDoor;
            this.isInsideHouseDoor = IsInsideHouseDoor;
            this.height = Height;
            this.length = Length;
            this.width = Width;
        }


        public void changeDoorState()
        {
            if (!(isOpen == true))
            {
                isOpen = false;
            }
            else
            {
                isOpen = true;
            }
        }

        public void change_EnterHouseDoor()
        {
            if (isEnterHouseDoor == false)
            {
                isEnterHouseDoor = true;
            }
            else
                isEnterHouseDoor = false;
        }

        public void change_InsideHouseDoor()
        {
            if (isInsideHouseDoor == true)
            {
                isInsideHouseDoor = false;
            }
            else
                isInsideHouseDoor = true;
        }

        public void WichTypeIsTheDoor(string type)
        {
            if (!Enum.IsDefined(typeof(EnumType), type))
            {
                throw new ArgumentException("Invalid type");
            }
            this.type = Enum.Parse<EnumType>(type);

        }

    }
}
