
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  public class CriticalSectionExample
  {
    public void StartThreads(bool useMonitor)
    {
      Thread[] m_Threads = new Thread[2];
      for (int i = 0; i < m_Threads.Length; i++)
        if (useMonitor)
          m_Threads[i] = new Thread(ThreadFuncWithMonitor);
        else
          m_Threads[i] = new Thread(ThreadFunc);
      foreach (Thread _thread in m_Threads)
        _thread.Start();
      foreach (Thread _thread in m_Threads)
        _thread.Join();
    }
    public void StartThreadsUsingThreadPool(bool useMonitor)
    {
      for (int i = 0; i < 2; i++)
        if (useMonitor)
          ThreadPool.QueueUserWorkItem(ThreadFuncWithMonitor);
        else
          ThreadPool.QueueUserWorkItem(ThreadFunc);
      //wait for threads
      //TODO must be improved it could cause race condition
      Thread.Sleep(1000);
    }
    public void StartThreadsUsingTask(bool useMonitor)
    {
      List<Task> _tasksInProgress = new List<Task>();
      for (int i = 0; i < 2; i++)
        if (useMonitor)
          Task.Run(() => ThreadFuncWithMonitor(useMonitor));
        else
          Task.Run(() => ThreadFunc(useMonitor));
      //wait for threads
      Task.WaitAll(_tasksInProgress.ToArray());
    }

    #region Monitor methods
    public int LockedNumber; // variable used to demonstrate 
                             // how monitors works

    public void NoMonitorMethod(object state)
    {
      for (int i = 0;
        i < 1000000;
        ++i)
      {
        ++LockedNumber;
      }
    }

    public void MonitorMethod(object state)
    {
      bool lockWasTaken = false;
      try
      {
        System.Threading.Monitor.Enter
          (this, ref lockWasTaken);
        for (int i = 0;
          i < 1000000;
          ++i)
        {
          ++LockedNumber;
        }
      }
      finally
      {
        if (lockWasTaken)
          System.Threading.Monitor.Exit(this);
      }
    }

    public void LockMethod(object state)
    {
      lock (this)
      {
        for (int i = 0;
            i < 1000000;
            ++i)
        {
          ++LockedNumber;
        }
      }
    }

    public void MonitorMethodWithTimeout(object state)
    {
      bool[] paramsObjects = state as bool[]; // a flag used for testing
      bool lockWasTaken = false;
      const int timeout = 1000; // 1 second
      try
      {
        System.Threading.Monitor.TryEnter
            (this, timeout, ref lockWasTaken);
        if (lockWasTaken)
        {
          System.Threading.Thread.Sleep(2000); // 2 seconds
        }
      }
      finally
      {
        if (lockWasTaken)
          System.Threading.Monitor.Exit(this);
        else
          paramsObjects[0] = true;
      }
    }

    // IMPORTANT: explaining the difference
    //            between ready queue 
    //            and waiting queue
    public void WaitMethod(object state)
    {
      lock (this)
      {
        for (int i = 0;
          i < 1000000;
          ++i)
        {
          ++LockedNumber;
        }
        System.Threading.Monitor.Wait(this);
        for (int i = 0;
          i < 2000000;
          ++i)
        {
          --LockedNumber;
        }
      }
    }

    public void PulseMethod(object state)
    {
      lock (this)
      {
        for (int i = 0;
          i < 1000000;
          ++i)
        {
          ++LockedNumber;
        }
        System.Threading.Monitor.Pulse(this);
        // Pulse sends a signal to the first
        // thread in waiting queue;
        // PulseAll sends signals to all of them
        // Signaled threads queue up in ready queue
      }
    }
    #endregion

    #region private
    private readonly object m_SyncObject = new object();
    private int m_IntegerA = 0;
    private int m_IntegerB = 0;
    private Random m_Random = new Random();
    private void ThreadFunc(object parameter)
    {
      DataProcessingSimulator();
    }
    private void ThreadFuncWithMonitor(object parameter)
    {
      lock (m_SyncObject)
      {
        DataProcessingSimulator();
      }
    }
    private void DataProcessingSimulator()
    {
      for (int i = 0; i < 1000000; i++)
      {
        int _value = m_Random.Next();
        m_IntegerA += _value;
        m_IntegerB -= _value;
        IsConsistent &= m_IntegerA - m_IntegerB == 0;
      }
    }
    #endregion

    #region UT Instrumentation
    /// <summary>
    /// Gets a value indicating whether this instance is consistent.
    /// </summary>
    /// <remarks>Always must be true.</remarks>
    /// <value><c>true</c> if this instance is consistent; otherwise, <c>false</c>.</value>
    internal bool IsConsistent { get; private set; } = true;
    #endregion

  }
}
