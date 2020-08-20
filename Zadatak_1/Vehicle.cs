using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    /// <summary>
    /// Base class to be inherited by other classes.
    /// </summary>
    abstract class Vehicle
    {
        public int Id { get; set; }
        public double MotorVolume { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string MotorType { get; set; }
        public string Paint { get; set; }
        public int MotorNumber { get; set; }
        public string RegMark { get; set; }
        public int LicenceNumber { get; set; }

        public Vehicle()
        {
        }

        public virtual void Start()
        {
        }
    }
}
