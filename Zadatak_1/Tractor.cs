using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    /// <summary>
    /// Class responsible for creating Tractor type objects, while deriving from Vehicle base class.
    /// </summary>
    class Tractor : Vehicle
    {
        public double TireSize { get; set; }
        public int BaseWidth { get; set; }
        public string Traction { get; set; }

        public Tractor() : base()
        {
        }

        public Tractor(string paint, string regMark, int liLicenceNumber)
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
            t.Name = string.Format("Tractor: |Paint: {0}| |Licence: {1}{2}|", Paint, RegMark, LicenceNumber);
            t.Start();
        }
    }
}
