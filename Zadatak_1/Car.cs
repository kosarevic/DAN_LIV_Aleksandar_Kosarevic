using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    /// <summary>
    /// Class responsible for creating Car type objects, while deriving from Vehicle base class.
    /// </summary>
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

        /// <summary>
        /// Method overriden and set to initiate each thread upon demand.
        /// </summary>
        public override void Start()
        {
            Thread t = new Thread(Program.RaceStarts);
            t.Name = string.Format("Car: |Paint: {0}| |Licence: {1}{2}|", Paint, RegMark, LicenceNumber);
            t.Start();
        }
    }
}
