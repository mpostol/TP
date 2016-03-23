using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrykiLib
{
    public class MetrykaTaksowkowa : IMiaraOdleglosci
    {
        public double ObliczOdleglosc(double[] a, double[] b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            if (a.Length != b.Length)
                throw new ArgumentOutOfRangeException(nameof (a));
            double sumaOdcinkow = 0;
            for(int i=0; i<a.Length;i++)
            {
                sumaOdcinkow += Math.Abs(a[i] - b[i]);
            }
            return sumaOdcinkow;
        }
    }
}
