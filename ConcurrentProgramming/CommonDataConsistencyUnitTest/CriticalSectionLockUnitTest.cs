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
  public class CriticalSectionLockUnitTest
  {
    /// <summary>
    /// Test lack of data consistency using manually created <seealso cref="Thread"/>.
    /// </summary>
    [TestMethod]
    public void LackOfDataConsistencyUsingManuallyCreatedThreads()
    {
      CriticalSectionLock m_ThreadsExample = new CriticalSectionLock();
      RunConcurrentlyManualyCreatedThreads(m_ThreadsExample.NoProtectedMethod);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    /// <summary>
    /// Test how to protect data consistency using critical section implemented using Monitor and manually created <seealso cref="Thread"/>.
    /// </summary>
    [TestMethod]
    public void CriticalSectionImplementedUsingMonitorManuallyCreatedThreads()
    {
      CriticalSectionLock m_ThreadsExample = new CriticalSectionLock();
      RunConcurrentlyManualyCreatedThreads(m_ThreadsExample.ProtectedMethod);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }

    /// <summary>
    /// Test lack of data consistency using <seealso cref="ThreadPool"/>.
    /// </summary>
    [TestMethod]
    public void LackOfDataConsistencyUsingThreadPool()
    {
      CriticalSectionLock m_ThreadsExample = new CriticalSectionLock();
      RunThreadsUsingThreadPool(m_ThreadsExample.NoProtectedMethod);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    /// <summary>
    /// Test how to protect data consistency using critical section implemented using Monitor and <seealso cref="ThreadPool"/>.
    /// </summary>
    [TestMethod]
    public void CriticalSectionImplementedUsingMonitorThreadPool()
    {
      CriticalSectionLock m_ThreadsExample = new CriticalSectionLock();
      RunThreadsUsingThreadPool(m_ThreadsExample.ProtectedMethod);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }

    /// <summary>
    /// Test lack of data consistency using manually created <seealso cref="Task"/>
    /// </summary>
    [TestMethod]
    public void CheckConsitencyUsingTaskNoMonitor()
    {
      CriticalSectionLock m_ThreadsExample = new CriticalSectionLock();
      RunThreadsUsingTask(m_ThreadsExample.NoProtectedMethod);
      Assert.IsFalse(m_ThreadsExample.IsConsistent);
    }

    /// <summary>
    /// Test how to protect data consistency using critical section implemented using Monitor and <seealso cref="Task"/>.
    /// </summary>
    [TestMethod]
    public void CheckWhetherThreadsUsingThreadPoolAreSynchronized()
    {
      CriticalSectionLock m_ThreadsExample = new CriticalSectionLock();
      RunThreadsUsingTask(m_ThreadsExample.ProtectedMethod);
      Assert.IsTrue(m_ThreadsExample.IsConsistent);
    }

    #region Test Instrumentation

    public void RunConcurrentlyManualyCreatedThreads(ParameterizedThreadStart start)
    {
      if (start == null)
        throw new ArgumentNullException(nameof(start));
      Thread[] threadsArray = new Thread[2];
      for (int i = 0; i < threadsArray.Length; i++)
        threadsArray[i] = new Thread(start);
      foreach (Thread _thread in threadsArray)
        _thread.Start();
      foreach (Thread _thread in threadsArray)
        _thread.Join();
    }

    public void RunThreadsUsingThreadPool(WaitCallback callBack)
    {
      for (int i = 0; i < 2; i++)
        ThreadPool.QueueUserWorkItem(callBack);
      //wait for threads
      //TODO must be improved it could cause race condition
      Thread.Sleep(1000);
    }

    public void RunThreadsUsingTask(WaitCallback callBack)
    {
      if (callBack == null)
        throw new ArgumentNullException(nameof(callBack));
      List<Task> _tasksInProgress = new List<Task>();
      for (int i = 0; i < 2; i++)
        _tasksInProgress.Add(Task.Run(() => callBack(null)));
      //wait for threads
      Task.WaitAll(_tasksInProgress.ToArray());
    }

    #endregion Test Instrumentation
  }
}