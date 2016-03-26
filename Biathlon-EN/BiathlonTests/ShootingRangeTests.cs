using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biathlon;
using Biathlon.Measurements;

namespace BiathlonTests
{
    [TestClass]
    public class ShootingRangeTests
    {
        [TestMethod]
        public void ShootingRangeSearchFirstNearest_null_if_not_hit()
        {
            ShootingRange sr = new ShootingRange();
            Point p = new Point(3.0, 4.0);

            Point result = sr.SearchFirstNearest(p, 2.0);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ShootingRangeFinishChecking_point_0_0_finishes_loop()
        {
            ShootingRange sr = new ShootingRange();
            Point p = new Point(0.0, 0.0);
            Assert.IsTrue(sr.FinishChecking(p));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShootingRangeFinishChecking_exception_when_Point_is_null()
        {
            ShootingRange sr = new ShootingRange();
            Assert.IsFalse(sr.FinishChecking(null));
        }

        [TestMethod]
        public void ShootingRangeFinishChecking_nonzero_point_repeats_loop()
        {
            ShootingRange sr = new ShootingRange();
            Point p = new Point(2.0, 5.0);
            Assert.IsFalse(sr.FinishChecking(p));
        }

        [TestMethod]
        public void ShootingRangeTargetHit()
        {
            ShootingRange sr = new ShootingRange();
            Point p = new Point(3.0, 4.0);
            Point target = new Point(3.5, 4.5);
            Assert.IsTrue(sr.TargetHit(p, target, 3.0));
        }
    }
}
