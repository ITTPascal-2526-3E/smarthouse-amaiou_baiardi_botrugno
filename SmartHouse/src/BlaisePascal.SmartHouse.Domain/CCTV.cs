using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class CCTV
    {
        public bool isOn = false;
        private int resolutionWidth { get; set; }
        private int resolutionHeight { get; set; }
        private int frameRate { get; set; }
        private int storageCapacity { get; set; } // in GB
        private bool nightVision { get; set; }
        private bool bulletProof { get; set; }
        public int ResolutionWidth
        {
            get { return resolutionWidth; }
            set { resolutionWidth = value; }
        }
        public int ResolutionHeight
        {
            get { return resolutionHeight; }
            set { resolutionHeight = value; }
        }
        public int FrameRate
        {
            get { return frameRate; }
            set { frameRate = value; }
        }
        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
        }
        public bool NightVision
        {
            get { return nightVision; }
            set { nightVision = value; }
        }

        public bool BulletProof
        {
            get { return bulletProof; }
            set { bulletProof = value; }
        }

    }  
}
