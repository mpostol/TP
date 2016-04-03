using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biathlon.Pomiary;
using MetrykiLib;

namespace BiathlonTests
{
    [TestClass]
    public class OdlegloscPunktowTests
    {
        [TestMethod]
        public void OdlegloscPunktowEuklidesowa()
        {
            Punkt p1 = new Punkt(10.0, 15.0);
            Punkt p2 = new Punkt(7.0, 19.0);
            IMiaraOdleglosci miara = new MetrykaEuklidesowa();
            OdlegloscPunktow odleglosc = new OdlegloscPunktow(miara);
            Assert.AreEqual(5.0, odleglosc.ObliczOdleglosc(p1, p2));
        }

        [TestMethod]
        public void OdlegloscPunktowTaksowkowa()
        {
            Punkt p1 = new Punkt(10.0, 15.0);
            Punkt p2 = new Punkt(7.0, 19.0);
            IMiaraOdleglosci miara = new MetrykaTaksowkowa();
            OdlegloscPunktow odleglosc = new OdlegloscPunktow(miara);
            Assert.AreEqual(7.0, odleglosc.ObliczOdleglosc(p1, p2));
        }
    }
}
