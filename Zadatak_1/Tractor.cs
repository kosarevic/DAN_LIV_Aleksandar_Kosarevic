using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Tractor : Vehicle
    {

        public double TireSize { get; set; }
        public int BaseWidth { get; set; }
        public string Traction { get; set; }

        public Tractor() : base()
        {
        }

    }
}
