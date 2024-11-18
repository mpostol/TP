//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using TP.ConcurrentProgramming.CommonDataConsistency;

namespace TP.ConcurrentProgramming.CommonDataConsistency.UnitTest
{
    [TestClass]
    public class CriticalSectionUnitTest
    {
        [TestMethod]
        public void CheckWhetherThreadsAreNotSynchronized()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            m_ThreadsExample.StartThreads(false);
            Assert.IsFalse(m_ThreadsExample.IsConsistent);
        }

        [TestMethod]
        public void CheckWhetherThreadsAreSynchronized()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            m_ThreadsExample.StartThreads(true);
            Assert.IsTrue(m_ThreadsExample.IsConsistent);
        }

        [TestMethod]
        public void CheckWhetherThreadsUsingThreadPoolAreNotSynchronized()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            m_ThreadsExample.StartThreadsUsingThreadPool(false);
            Assert.IsFalse(m_ThreadsExample.IsConsistent);
        }

        [TestMethod]
        public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            m_ThreadsExample.StartThreadsUsingThreadPool(true);
            Assert.IsTrue(m_ThreadsExample.IsConsistent);
        }

        [TestMethod]
        public void MonitorMethodTest()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.MonitorMethod);
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.MonitorMethod);
            Thread.Sleep(SleepTime); // wait for threads
            const int _expectedCycles = 2 * 1000000; // twice the number of iterations
            Assert.AreEqual(_expectedCycles, m_ThreadsExample.LockedNumber);
        }

        [TestMethod]
        public void LockMethodTest()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.LockMethod);
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.LockMethod);
            Thread.Sleep(SleepTime); // wait for threads
            Assert.AreEqual(2 * 1000000, m_ThreadsExample.LockedNumber);
        }

        [TestMethod]
        public void NoMonitorMethodTest()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.NoMonitorMethod);
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.NoMonitorMethod);
            Thread.Sleep(SleepTime); // wait for threads
            Assert.AreNotEqual(2 * 1000000, m_ThreadsExample.LockedNumber);
        }

        [TestMethod]
        public void MonitorMethodWithTimeoutTest()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            object tab = new bool[] { false };
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.MonitorMethodWithTimeout, tab);
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.MonitorMethodWithTimeout, tab);
            Assert.AreEqual(false, ((bool[])tab)[0]);
            Thread.Sleep(2000); // 2 seconds - wait the timeout
            Assert.AreEqual(true, ((bool[])tab)[0]);
        }

        [TestMethod]
        public void WaitPulseMethodsTest()
        {
            CriticalSection m_ThreadsExample = new CriticalSection();
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.WaitMethod);
            Thread.Sleep(SleepTime);
            ThreadPool.QueueUserWorkItem(m_ThreadsExample.PulseMethod);
            Thread.Sleep(SleepTime); // wait for threads
            Assert.AreEqual(0, m_ThreadsExample.LockedNumber);
        }

        private const int SleepTime = 512; // ms
    }
}