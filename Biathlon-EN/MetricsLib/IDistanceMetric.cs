using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsLib
{
    public interface IDistanceMetric
    {
        double CalculateDistance(double[] a, double[] b);
    }
}
