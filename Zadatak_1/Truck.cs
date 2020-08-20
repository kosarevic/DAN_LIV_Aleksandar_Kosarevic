using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Truck : Vehicle
    {
        /// <summary>
        /// Class responsible for creating Truck type objects, while deriving from Vehicle base class.
        /// </summary>
        public double Capacity { get; set; }
        public double Height { get; set; }
        public int Seats { get; set; }

        public Truck() : base()
        {
        }

        public Truck(string paint, string regMark, int liLicenceNumber)
        {
            Paint = paint;
            RegMark = regMark;
            LicenceNumber = liLicenceNumber;
        }

        /// <summary>
        /// Method overriden and set to initiate each thread upon demand.
        /// </summary>
        public override void Start()
        {
            Thread t = new Thread(Program.RaceStarts);
            t.Name = string.Format("Truck: |Paint: {0}| |Licence: {1}{2}|", Paint, RegMark, LicenceNumber);
            t.Start();
        }

    }
}
