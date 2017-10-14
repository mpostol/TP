using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.AsynchronousBehavior.Threading;

namespace ThreadingUnitTest
{
    [TestClass]
    public class ThreadsExampleUnitTest
    {
        private ThreadsExample _threadsExample;

        [TestInitialize]
        public void Init()
        {
            _threadsExample = new ThreadsExample();
        }

        [TestMethod]
        public void CheckWhetherThreadsAreNotSynchronized()
        {
            _threadsExample.StartThreads(false);

            Assert.IsFalse(_threadsExample.A + _threadsExample.B == 0);
        }

        [TestMethod]
        public void CheckWhetherThreadsAreSynchronized()
        {
            _threadsExample.StartThreads(true);

            Assert.IsTrue(_threadsExample.A + _threadsExample.B == 0);
        }

        [TestMethod]
        public void CheckWhetherThreadsUsingThreadPoolAreNotSynchronized()
        {
            _threadsExample.StartThreadsUsingThreadPool(false);

            Assert.IsFalse(_threadsExample.A + _threadsExample.B == 0);
        }

        [TestMethod]
        public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
        {
            _threadsExample.StartThreadsUsingThreadPool(true);

            Assert.IsTrue(_threadsExample.A + _threadsExample.B == 0);
        }
    }
}
