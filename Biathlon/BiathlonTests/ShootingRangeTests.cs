using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biathlon;
using Biathlon.Measurements;
using MetricsLib;
using BiathlonTests.InOut;
using System.Collections.Generic;

namespace BiathlonTests
{
    [TestClass]
    public class ShootingRangeTests
    {
        // Class under test
        private ShootingRange cut;

        public ShootingRangeTests()
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
            IDistanceMetric metric = new EuclideanDistance();
            PointsDistance distance = new PointsDistance(metric);
            this.cut = new ShootingRange(distance);
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
        public void ShootingRangeSearchFirstNearest_null_if_not_hit()
        {
            Point p = new Point(3.0, 4.0);

            Point result = cut.SearchFirstNearest(p, 2.0);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ShootingRangeFinishChecking_point_0_0_finishes_loop()
        {
            Point p = new Point(0.0, 0.0);
            Assert.IsTrue(cut.FinishChecking(p));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShootingRangeFinishChecking_exception_when_Point_is_null()
        {
            Assert.IsFalse(cut.FinishChecking(null));
        }

        [TestMethod]
        public void ShootingRangeFinishChecking_nonzero_point_repeats_loop()
        {
            Point p = new Point(2.0, 5.0);
            Assert.IsFalse(cut.FinishChecking(p));
        }

        [TestMethod]
        public void ShootingRangeTargetHit_hit_when_radius_3_distance_small()
        {
            Point p = new Point(3.0, 4.0);
            Point target = new Point(3.5, 4.5);
            Assert.IsTrue(cut.TargetHit(p, target, 3.0));
        }

        [TestMethod]
        public void ShootingRangeTargetHit_miss_when_radius_2_distance_large()
        {
            Point p = new Point(3.0, 4.0);
            Point target = new Point(13.5, 14.5);
            Assert.IsFalse(cut.TargetHit(p, target, 2.0));
        }

        [TestMethod]
        public void ShootingRangeSearchFirstNearest_miss_when_0_0_first()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 0.0, 0.0 }))
            {
                Point p = new Point(3.5, 4.5);
                Point result = cut.SearchFirstNearest(p, 3.0);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void ShootingRangeSearchFirstNearest_miss_when_radius_2_distance_large()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 3.0, 4.0, 0.0, 0.0 }))
            {
                Point p = new Point(13.5, 14.5);
                Point result = cut.SearchFirstNearest(p, 2.0);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void ShootingRangeSearchFirstNearest_hit_first()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 3.0, 4.0, 0.0, 0.0 }))
            {
                Point p = new Point(3.5, 4.5);
                Point result = cut.SearchFirstNearest(p, 3.0);

                Assert.IsNotNull(result);
                Assert.AreEqual(3.0, result.X);
                Assert.AreEqual(4.0, result.Y);
            }
        }

        [TestMethod]
        public void ShootingRangeSearchFirstNearest_hit_third()
        {
            using (ConsoleInput cin = new ConsoleInput(new List<Double> { 10.0, 1.0, -2, -10, 3.0, 4.0, 0.0, 0.0 }))
            {
                Point p = new Point(3.5, 4.5);
                Point result = cut.SearchFirstNearest(p, 3.0);

                Assert.IsNotNull(result);
                Assert.AreEqual(3.0, result.X);
                Assert.AreEqual(4.0, result.Y);
            }
        }
    }
}
