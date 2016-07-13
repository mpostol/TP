using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiathlonTests.InOut;
using System.Collections.Generic;
using Biathlon.Pomiary;

namespace BiathlonTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramMain_pudlo_gdy_0_0_pierwsze()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    3.5, 4.5,
                    0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Poczatkowy X: Poczatkowy Y: " +
                        "X: Y: " +
                        "Nie trafiono{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }

        [TestMethod]
        public void ProgramMain_pudlo_gdy_promien_2_odleglosc_duza()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    13.5, 14.5,
                    3.0, 4.0, 0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Poczatkowy X: Poczatkowy Y: " +
                        "X: Y: " +
                        "X: Y: " +
                        "Nie trafiono{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }

        [TestMethod]
        public void ProgramMain_trafienie_pierwszego()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    3.5, 4.5,
                    3.0, 4.0, 0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Poczatkowy X: Poczatkowy Y: " +
                        "X: Y: " +
                        "Trafienie!{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }

        [TestMethod]
        public void ProgramMain_trafienie_trzeciego()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    3.5, 4.5,
                    10.0, 1.0, -2, -10, 3.0, 4.0, 0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Poczatkowy X: Poczatkowy Y: " +
                        "X: Y: " +
                        "X: Y: " +
                        "X: Y: " +
                        "Trafienie!{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }
    }
}
