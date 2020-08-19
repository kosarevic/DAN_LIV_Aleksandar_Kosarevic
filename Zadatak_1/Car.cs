using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Car : Vehicle
    {

        public string RegMark { get; set; }
        public int Doors { get; set; }
        public int TankVolume { get; set; }
        public string TransmitionType { get; set; }
        public string Manufacturer { get; set; }
        public int LicenceNumber { get; set; }

        public void ChangePaint(string color, int newLicenceNumber)
        {
            Paint = color;
            LicenceNumber = newLicenceNumber;
        }

    }
}
