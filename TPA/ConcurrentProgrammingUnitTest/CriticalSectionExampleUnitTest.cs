
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming.UnitTest
{

  [TestClass]
  public class CriticalSectionExampleUnitTest
  {
    [TestInitialize]
    public void TestInitialize()
    {
      m_ThreadsExample = new CriticalSectionExample();
    }
    [TestMethod]
    public void CheckWhetherThreadsAreNotSynchronized()
    {
      m_ThreadsExample.StartThreads(false);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsAreSynchronized()
    {
      m_ThreadsExample.StartThreads(true);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreNotSynchronized()
    {
      m_ThreadsExample.StartThreadsUsingThreadPool(false);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
    {
      m_ThreadsExample.StartThreadsUsingThreadPool(true);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    [TestMethod]
    public void MonitorMethodTest()
    {
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.MonitorMethod);
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.MonitorMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreEqual(2 * 1000000,  // twice the number of iterations
          m_ThreadsExample.LockedNumber);
    }

    [TestMethod]
    public void LockMethodTest()
    {
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.LockMethod);
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.LockMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreEqual(2 * 1000000,
          m_ThreadsExample.LockedNumber);
    }

    [TestMethod]
    public void NoMonitorMethodTest()
    {
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.NoMonitorMethod);
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.NoMonitorMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreNotEqual(2 * 1000000,
          m_ThreadsExample.LockedNumber);
    }

    [TestMethod]
    public void MonitorMethodWithTimeoutTest()
    {
      object tab = new bool[1];
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.MonitorMethodWithTimeout, tab);
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.MonitorMethodWithTimeout, tab);
      Assert.AreEqual(false, ((bool[])tab)[0]);
      Thread.Sleep(2000); // 2 seconds - wait the timeout
      Assert.AreEqual(true, ((bool[])tab)[0]);
    }

    [TestMethod]
    public void WaitPulseMethodsTest()
    {
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.WaitMethod);
      Thread.Sleep(SleepTime);
      ThreadPool.QueueUserWorkItem
          (m_ThreadsExample.PulseMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreEqual(0,
          m_ThreadsExample.LockedNumber);
    }

    [TestMethod()]
    public void SynchronizationAttributeNoMonitorMethodTest()
    {
      SynchronizationAttributeExample example = new SynchronizationAttributeExample();
      ThreadPool.QueueUserWorkItem
        (example.NoMonitorMethod);
      ThreadPool.QueueUserWorkItem
        (example.NoMonitorMethod);
      Thread.Sleep(SleepTime); // wait for threads
      Assert.AreEqual(2 * 1000000,  // twice the number of iterations
        example.LockedNumber);
    }

    private const int SleepTime = 512; // ms
    private CriticalSectionExample m_ThreadsExample;

  }
}
