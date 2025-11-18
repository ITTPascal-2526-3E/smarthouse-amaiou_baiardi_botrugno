using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Door
    {
        private bool isOpen = false;
        private string material {  get; set; }
        private string type {  get; set; }
        private bool isBulletProof = true;
        private bool isEnterHouseDoor = true;
        private bool isInsideHouseDoor = false;
        private double height, length, width;

        public void changeDoorState() 
        {
            isOpen = true;
        }

        public void changeLength(double value) 
        { 
            length = value;
        }

        public void changeWidth(double value)
        {
            width = value;
        }

        public void changeHeight(double value)
        {
            height = value;
        }
    }
}