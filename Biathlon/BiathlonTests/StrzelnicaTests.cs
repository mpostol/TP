using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biathlon;
using Biathlon.Pomiary;

namespace BiathlonUnitTests
{
    [TestClass]
    public class StrzelnicaTests
    {
        [TestMethod]
        public void StrzelnicaSzukajPierwszegoNajblizszego_null_gdy_nie_trafiono()
        {
            Strzelnica st = new Strzelnica();
            Punkt p = new Punkt(3.0, 4.0);

            Punkt wynik = st.SzukajPierwszegoNajblizszego(p, 2.0);
            Assert.IsNull(wynik);
        }

        [TestMethod]
        public void StrzelnicaKoniecSprawdzania_punkt_0_0_konczy_petle()
        {
            Strzelnica st = new Strzelnica();
            Punkt p = new Punkt(0.0, 0.0);
            Assert.IsTrue(st.KoniecSprawdzania(p));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StrzelnicaKoniecSprawdzania_wyjatek_gdy_Punkt_null()
        {
            Strzelnica st = new Strzelnica();
            Assert.IsFalse(st.KoniecSprawdzania(null));
        }

        [TestMethod]
        public void StrzelnicaKoniecSprawdzania_niezerowe_punkty_powtarzaja_petle()
        {
            Strzelnica st = new Strzelnica();
            Punkt p = new Punkt(2.0, 5.0);
            Assert.IsFalse(st.KoniecSprawdzania(p));
        }

        [TestMethod]
        public void StrzelnicaSprawdzTrafienie()
        {
            Strzelnica st = new Strzelnica();
            Punkt p = new Punkt(3.0, 4.0);
            Punkt zadany = new Punkt(3.5, 4.5);
            Assert.IsTrue(st.SprawdzTrafienie(p, zadany, 3.0));
        }
    }
}
