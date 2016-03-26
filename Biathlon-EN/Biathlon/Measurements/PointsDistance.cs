using MetricsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biathlon.Measurements
{
    public class PointsDistance
    {
        private IDistanceMetric Gauge;

        public PointsDistance(IDistanceMetric gauge)
        {
            if (gauge == null)
                throw new ArgumentNullException(nameof(gauge));
            Gauge = gauge;
        }

        public double CalculateDistance(Point p1, Point p2)
        {
            double[] a = { p1.X, p1.Y };
            double[] b = { p2.X, p2.Y };
            return Gauge.CalculateDistance(a, b);
        }
    }
}
