using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    abstract class Vehicle
    {

        public double MotorVolume { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string MotorType { get; set; }
        public string Paint { get; set; }
        public int MotorNumber { get; set; }

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }


    }
}
