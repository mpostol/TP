//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.CommonDataConsistency.UnitTest
{
  [TestClass]
  public class CriticalSectionUnitTest
  {
    [TestMethod]
    public void CheckWhetherThreadsAreNotSynchronized()
    {
      CriticalSection m_ThreadsExample = new CriticalSection();
      StartThreads(m_ThreadsExample.NoMonitorMethod);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    [TestMethod]
    public void CheckWhetherThreadsAreSynchronized()
    {
      CriticalSection m_ThreadsExample = new CriticalSection();
      StartThreads(m_ThreadsExample.MonitorMethod);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }

    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreNotSynchronized()
    {
      CriticalSection m_ThreadsExample = new CriticalSection();
      StartThreadsUsingThreadPool(m_ThreadsExample.NoMonitorMethod);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    [TestMethod]
    public void CheckConsitencyUsingTaskMonitor()
    {
      CriticalSection m_ThreadsExample = new CriticalSection();
      StartThreadsUsingThreadPool(m_ThreadsExample.MonitorMethod);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }
    [TestMethod]
    public void CheckConsitencyUsingTaskNoMonitor()
    {
      CriticalSection m_ThreadsExample = new CriticalSection();
      RunThreadsUsingTask(m_ThreadsExample.NoMonitorMethod);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
    {
      CriticalSection m_ThreadsExample = new CriticalSection();
      RunThreadsUsingTask(m_ThreadsExample.MonitorMethod);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
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

    #region Test Instrumentation

    private const int SleepTime = 512; // ms

    public void StartThreads(ParameterizedThreadStart start)
    {
      Thread[] threadsArray = new Thread[2];
      for (int i = 0; i < threadsArray.Length; i++)
        threadsArray[i] = new Thread(start);
      foreach (Thread _thread in threadsArray)
        _thread.Start();
      foreach (Thread _thread in threadsArray)
        _thread.Join();
    }

    public void StartThreadsUsingThreadPool(WaitCallback callBack)
    {
      for (int i = 0; i < 2; i++)
        ThreadPool.QueueUserWorkItem(callBack);
      //wait for threads
      //TODO must be improved it could cause race condition
      Thread.Sleep(1000);
    }

    public void RunThreadsUsingTask(WaitCallback? callBack)
    {
      if (callBack == null)
        throw new ArgumentNullException(nameof(callBack));
      List<Task> _tasksInProgress = new List<Task>();
      for (int i = 0; i < 2; i++)
      {
        Task newTask = Task.Run(() => callBack(null));
        _tasksInProgress.Add(newTask);
      }
      //wait for threads
      Task.WaitAll(_tasksInProgress.ToArray());
    }

    #endregion Test Instrumentation
  }
}