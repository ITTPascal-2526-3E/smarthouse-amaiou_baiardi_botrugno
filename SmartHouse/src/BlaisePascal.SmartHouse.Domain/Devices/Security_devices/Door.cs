using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Security_devices
{
    public class Door
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private bool isOpen { get; set; }
        private string material { get; set; }
        private string type { get; set; }
        private bool isBulletProof { get; set; }
        private bool isEnterHouseDoor { get; set; }
        private bool isInsideHouseDoor { get; set; }
        private double height, length, width;

        public Door(bool IsOpen, string Material, string Type, bool IsBulletProof, bool IsEnterHouseDoor, bool IsInsideHouseDoor, double Height, double Length, double Width)
        {
            Id = Guid.NewGuid();
            isOpen = IsOpen;
            this.material = Material;
            this.type = Type;
            this.isBulletProof = IsBulletProof;
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

        public void changeLength(double value)
        {
            if (value <= 0.0)
            {
                throw new ArgumentOutOfRangeException("Length cannot be negative.");
            }
            else
                length = value;
        }

        public void changeWidth(double value)
        {
            if (value <= 0.0)
            {
                throw new ArgumentOutOfRangeException("Width cannot be negative.");
            }
            else
                width = value;
        }

        public void changeHeight(double value)
        {
            if (value <= 0.0)
            {
                throw new ArgumentOutOfRangeException("Height cannot be negative.");
            }
            else
                height = value;
        }

        public void change_BulletProof()
        {
            if (isBulletProof == false)
            {
                isBulletProof = true;
            }
            else
                isBulletProof = false;
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
    }
}
