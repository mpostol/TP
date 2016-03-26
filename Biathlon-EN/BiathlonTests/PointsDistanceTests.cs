using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biathlon.Measurements;
using MetricsLib;

namespace BiathlonTests
{
    [TestClass]
    public class PointsDistanceTests
    {
        [TestMethod]
        public void PointsDistanceEuclidean()
        {
            Point p1 = new Point(10.0, 15.0);
            Point p2 = new Point(7.0, 19.0);
            IDistanceMetric metric = new EuclideanDistance();
            PointsDistance distance = new PointsDistance(metric);
            Assert.AreEqual(5.0, distance.CalculateDistance(p1, p2));
        }

        [TestMethod]
        public void PointsDistanceTaxicab()
        {
            Point p1 = new Point(10.0, 15.0);
            Point p2 = new Point(7.0, 19.0);
            IDistanceMetric metric = new TaxicabDistance();
            PointsDistance distance = new PointsDistance(metric);
            Assert.AreEqual(7.0, distance.CalculateDistance(p1, p2));
        }
    }
}
