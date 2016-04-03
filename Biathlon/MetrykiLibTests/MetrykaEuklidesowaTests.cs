using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetrykiLib;

namespace MetrykiLibTests
{
    [TestClass]
    public class MetrykaEuklidesowaTests
    {
        [TestMethod]
        public void EuklidesowaObliczOdleglosc_dla3i4_oczekiwane5()
        {
            double[] a = { 10.0, 34.0 };
            double[] b = { 13.0, 38.0 };
            MetrykaEuklidesowa miara = new MetrykaEuklidesowa();
            double wynik = miara.ObliczOdleglosc(a, b);
            Assert.AreEqual(5.0, wynik);
        }
    }
}
