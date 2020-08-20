using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Car : Vehicle
    {
        public int Doors { get; set; }
        public int TankVolume { get; set; }
        public string TransmitionType { get; set; }
        public string Manufacturer { get; set; }

        public Car() : base()
        {
        }

        public Car(string paint, string regMark, int liLicenceNumber)
        {
            Paint = paint;
            RegMark = regMark;
            LicenceNumber = liLicenceNumber;
        }

        public void ChangePaint(string color, int newLicenceNumber)
        {
            Paint = color;
            LicenceNumber = newLicenceNumber;
        }

        public override void Start()
        {
            Thread t = new Thread(Program.RaceStarts);
            t.Name = string.Format("Car: |Paint: {0}| |Licence: {1}{2}|", Paint, RegMark, LicenceNumber);
            t.Start();
        }
    }
}
