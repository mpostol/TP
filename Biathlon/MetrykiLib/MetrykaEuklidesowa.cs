using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrykiLib
{
    public class MetrykaEuklidesowa : IMiaraOdleglosci
    {
        public double ObliczOdleglosc(double[] a, double[] b)
        {
            Debug.Assert(a != null && b!=null && a.Length == b.Length);
            double sumaKwadratow = 0.0;
            for(int i = 0; i<a.Length; i++)
            {
                double d = a[i] - b[i];
                sumaKwadratow += d * d;
            }
            return Math.Sqrt(sumaKwadratow);
        }
    }
}
