using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetrykiLib;

namespace MetrykiLibTests
{
    /// <summary>
    /// Summary description for MetrykaTaksowkowaTests
    /// </summary>
    [TestClass]
    public class MetrykaTaksowkowaTests
    {
        [TestMethod]
        public void TaksowkowaObliczOdlegosc_rozniceUjemneDlugoscDodatnia()
        {
            double[] a = { 10.0, 34.0 };
            double[] b = { 13.0, 38.0 };
            MetrykaTaksowkowa miara = new MetrykaTaksowkowa();
            double wynik = miara.ObliczOdleglosc(a, b);
            Assert.AreEqual(7.0, wynik);
        }
    }
}
