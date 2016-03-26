using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetricsLib;

namespace MetricsLibTests
{
    [TestClass]
    public class TaxicabDistanceTests
    {
        [TestMethod]
        public void TaxicabCalculateDistance_differencesNegativeDistancePositive()
        {
            double[] a = { 10.0, 34.0 };
            double[] b = { 13.0, 38.0 };
            TaxicabDistance metric = new TaxicabDistance();
            double result = metric.CalculateDistance(a, b);
            Assert.AreEqual(7.0, result);
        }
    }
}
