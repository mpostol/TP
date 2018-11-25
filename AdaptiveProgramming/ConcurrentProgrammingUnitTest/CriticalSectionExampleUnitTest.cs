//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming.UnitTest
{

  [TestClass]
  public class CriticalSectionExampleUnitTest
  {

    [TestMethod]
    public void CheckWhetherThreadsAreNotSynchronized()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      m_ThreadsExample.StartThreads(false);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsAreSynchronized()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      m_ThreadsExample.StartThreads(true);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreNotSynchronized()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      m_ThreadsExample.StartThreadsUsingThreadPool(false);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      m_ThreadsExample.StartThreadsUsingThreadPool(true);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void MonitorMethodTest()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.MonitorMethod);
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.MonitorMethod);
      Thread.Sleep(SleepTime); // wait for threads
      const int _expectedCycles = 2 * 1000000; // twice the number of iterations
      Assert.AreEqual(_expectedCycles, m_ThreadsExample.LockedNumber);
    }
    [TestMethod]
    public void LockMethodTest()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.LockMethod);
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.LockMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreEqual(2 * 1000000, m_ThreadsExample.LockedNumber);
    }
    [TestMethod]
    public void NoMonitorMethodTest()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.NoMonitorMethod);
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.NoMonitorMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreNotEqual(2 * 1000000, m_ThreadsExample.LockedNumber);
    }
    [TestMethod]
    public void MonitorMethodWithTimeoutTest()
    {
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
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
      CriticalSectionExample m_ThreadsExample = new CriticalSectionExample();
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.WaitMethod);
      Thread.Sleep(SleepTime);
      ThreadPool.QueueUserWorkItem(m_ThreadsExample.PulseMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreEqual(0, m_ThreadsExample.LockedNumber);
    }
    [TestMethod()]
    public void SynchronizationAttributeNoMonitorMethodTest()
    {
      SynchronizationAttributeExample _example = new SynchronizationAttributeExample();
      ThreadPool.QueueUserWorkItem(_example.NoMonitorMethod);
      ThreadPool.QueueUserWorkItem(_example.NoMonitorMethod);
      Thread.Sleep(300); // wait for threads
      const int _expectedCycles = 2 * 10; // twice the number of iterations
      Assert.AreEqual(_expectedCycles, _example.LockedNumber, $"{_example.LockedNumber}");
    }

    private const int SleepTime = 512; // ms

  }
}
