using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biathlon.Pomiary
{
    public class Punkt
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Punkt() { }
        public Punkt(double x, double y)
        {
            X = x;
            Y = y;
        }

    }
}
