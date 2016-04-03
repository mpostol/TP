using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsLib
{
    public class TaxicabDistance : IDistanceMetric
    {
        public double CalculateDistance(double[] a, double[] b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            if (a.Length != b.Length)
                throw new ArgumentOutOfRangeException(nameof(a));
            double sumOfLengths = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sumOfLengths += Math.Abs(a[i] - b[i]);
            }
            return sumOfLengths;
        }
    }
}
