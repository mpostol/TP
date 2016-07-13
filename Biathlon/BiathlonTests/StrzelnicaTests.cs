using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biathlon;
using Biathlon.Pomiary;
using MetrykiLib;
using BiathlonTests.InOut;
using System.Collections.Generic;

namespace BiathlonUnitTests
{
    [TestClass]
    public class StrzelnicaTests
    {
        // Class under test
        private Strzelnica cut;

        public StrzelnicaTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //#region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //

        // Use AssemblyInitialize to run code before all tests in the assembly have run
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
        }
        
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void Initialize()
        {
            // Composition root (for unit tests)
            // Compose objects here using Dependency Injection
            IMiaraOdleglosci miara = new MetrykaEuklidesowa();
            OdlegloscPunktow odleglosc = new OdlegloscPunktow(miara);
            this.cut = new Strzelnica(odleglosc);
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void Cleanup()
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use AssemblyCleanup to run code after all tests in the assembly have run
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
        }
        //#endregion

        [TestMethod]
        public void StrzelnicaSzukajPierwszegoNajblizszego_null_gdy_nie_trafiono()
        {
            Punkt p = new Punkt(3.0, 4.0);

            Punkt wynik = cut.SzukajPierwszegoNajblizszego(p, 2.0);
            Assert.IsNull(wynik);
        }

        [TestMethod]
        public void StrzelnicaKoniecSprawdzania_punkt_0_0_konczy_petle()
        {
            Punkt p = new Punkt(0.0, 0.0);
            Assert.IsTrue(cut.KoniecSprawdzania(p));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StrzelnicaKoniecSprawdzania_wyjatek_gdy_Punkt_null()
        {
            Assert.IsFalse(cut.KoniecSprawdzania(null));
        }

        [TestMethod]
        public void StrzelnicaKoniecSprawdzania_niezerowe_punkty_powtarzaja_petle()
        {
            Punkt p = new Punkt(2.0, 5.0);
            Assert.IsFalse(cut.KoniecSprawdzania(p));
        }

        [TestMethod]
        public void StrzelnicaSprawdzTrafienie_trafienie_gdy_promien_3_odleglosc_mala()
        {
            Punkt p = new Punkt(3.0, 4.0);
            Punkt zadany = new Punkt(3.5, 4.5);
            Assert.IsTrue(cut.SprawdzTrafienie(p, zadany, 3.0));
        }

        [TestMethod]
        public void StrzelnicaSprawdzTrafienie_pudlo_gdy_promien_2_odleglosc_duza()
        {
            Punkt p = new Punkt(3.0, 4.0);
            Punkt zadany = new Punkt(13.5, 14.5);
            Assert.IsFalse(cut.SprawdzTrafienie(p, zadany, 2.0));
        }

        [TestMethod]
        public void StrzelnicaSzukajPierwszegoNajblizszego_pudlo_gdy_0_0_pierwsze()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 0.0, 0.0 }))
            {
                Punkt zadany = new Punkt(3.5, 4.5);
                Punkt wynik = cut.SzukajPierwszegoNajblizszego(zadany, 3.0);

                Assert.IsNull(wynik);
            }
        }

        [TestMethod]
        public void StrzelnicaSzukajPierwszegoNajblizszego_pudlo_gdy_promien_2_odleglosc_duza()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 3.0, 4.0, 0.0, 0.0 }))
            {
                Punkt zadany = new Punkt(13.5, 14.5);
                Punkt wynik = cut.SzukajPierwszegoNajblizszego(zadany, 2.0);

                Assert.IsNull(wynik);
            }
        }

        [TestMethod]
        public void StrzelnicaSzukajPierwszegoNajblizszego_trafienie_pierwszego()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 3.0, 4.0, 0.0, 0.0 }))
            {
                Punkt zadany = new Punkt(3.5, 4.5);
                Punkt wynik = cut.SzukajPierwszegoNajblizszego(zadany, 3.0);

                Assert.IsNotNull(wynik);
                Assert.AreEqual(3.0, wynik.X);
                Assert.AreEqual(4.0, wynik.Y);
            }
        }

        [TestMethod]
        public void StrzelnicaSzukajPierwszegoNajblizszego_trafienie_trzeciego()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 10.0, 1.0, -2, -10, 3.0, 4.0, 0.0, 0.0 }))
            {
                Punkt zadany = new Punkt(3.5, 4.5);
                Punkt wynik = cut.SzukajPierwszegoNajblizszego(zadany, 3.0);

                Assert.IsNotNull(wynik);
                Assert.AreEqual(3.0, wynik.X);
                Assert.AreEqual(4.0, wynik.Y);
            }
        }

    }
}
