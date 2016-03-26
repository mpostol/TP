using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsLib
{
    public class EuclideanDistance : IDistanceMetric
    {
        public double CalculateDistance(double[] a, double[] b)
        {
            Debug.Assert(a != null && b != null && a.Length == b.Length);
            double sumOfSquares = 0.0;
            for (int i = 0; i < a.Length; i++)
            {
                double d = a[i] - b[i];
                sumOfSquares += d * d;
            }
            return Math.Sqrt(sumOfSquares);
        }
    }
}
