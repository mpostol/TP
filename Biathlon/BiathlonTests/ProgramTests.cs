using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiathlonTests.InOut;
using System.Collections.Generic;
using Biathlon.Measurements;

namespace BiathlonTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramMain_miss_when_0_0_first()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    3.5, 4.5,
                    0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Initial X: Initial Y: " +
                        "X: Y: " +
                        "There was no hit{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }

        [TestMethod]
        public void ProgramMain_miss_when_radius_2_distance_large()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    13.5, 14.5,
                    3.0, 4.0, 0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Initial X: Initial Y: " +
                        "X: Y: " +
                        "X: Y: " +
                        "There was no hit{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }

        [TestMethod]
        public void ProgramMain_hit_first()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    3.5, 4.5,
                    3.0, 4.0, 0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Initial X: Initial Y: " +
                        "X: Y: " +
                        "You hit it!{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }

        [TestMethod]
        public void ProgramMain_hit_third()
        {
            using (ConsoleOutput cout = new ConsoleOutput())
            {
                using (ConsoleInput cin = new ConsoleInput(new List<Double> {
                    3.5, 4.5,
                    10.0, 1.0, -2, -10, 3.0, 4.0, 0.0, 0.0 }))
                {
                    Biathlon.Program.Main();

                    string expected = String.Format(
                        "Biathlon{0}Initial X: Initial Y: " +
                        "X: Y: " +
                        "X: Y: " +
                        "X: Y: " +
                        "You hit it!{0}",
                        Environment.NewLine);
                    Assert.AreEqual(expected, cout.GetOuput());
                }
            }
        }
    }
}
