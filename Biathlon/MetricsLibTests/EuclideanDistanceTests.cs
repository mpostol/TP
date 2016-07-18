using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetricsLib;

namespace MetricsLibTests
{
    [TestClass]
    public class EuclideanDistanceTests
    {
        [TestMethod]
        public void EuclideanCalculateDistance_for3and4_expected5()
        {
            double[] a = { 10.0, 34.0 };
            double[] b = { 13.0, 38.0 };
            EuclideanDistance metric = new EuclideanDistance();
            double result = metric.CalculateDistance(a, b);
            Assert.AreEqual(5.0, result);
        }
    }
}
