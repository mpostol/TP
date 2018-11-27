//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  public class CriticalSectionExample
  {
    #region To be moved to UT
    public void StartThreads(bool useMonitor)
    {
      Thread[] _Threads = new Thread[2];
      for (int i = 0; i < _Threads.Length; i++)
        if (useMonitor)
          _Threads[i] = new Thread(ThreadFuncWithMonitor);
        else
          _Threads[i] = new Thread(ThreadFunc);
      foreach (Thread _thread in _Threads)
        _thread.Start();
      foreach (Thread _thread in _Threads)
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
      //TODO _tasksInProgress is always empty.
      Task.WaitAll(_tasksInProgress.ToArray());
    }
    #endregion

    #region Monitor methods
    public int LockedNumber; // variable used to demonstrate how monitors works
    public void NoMonitorMethod(object state)
    {
      for (int i = 0; i < 1000000; ++i)
        ++LockedNumber;
    }
    public void MonitorMethod(object state)
    {
      bool lockWasTaken = false;
      try
      {
        Monitor.Enter(this, ref lockWasTaken);
        for (int i = 0; i < 1000000; ++i)
          ++LockedNumber;
      }
      finally
      {
        if (lockWasTaken)
          Monitor.Exit(this);
      }
    }
    public void LockMethod(object state)
    {
      lock (this)
      {
        for (int i = 0; i < 1000000; ++i)
          ++LockedNumber;
      }
    }
    public void MonitorMethodWithTimeout(object state)
    {
      bool[] _parametersObjects = state as bool[]; // a flag used for testing
      bool _lockWasTaken = false;
      const int timeout = 1000; // 1 second
      try
      {
        Monitor.TryEnter(this, timeout, ref _lockWasTaken);
        if (_lockWasTaken)
          Thread.Sleep(2000); // 2 seconds
      }
      finally
      {
        if (_lockWasTaken)
          Monitor.Exit(this);
        else
          _parametersObjects[0] = true;
      }
    }
    // IMPORTANT: explaining the difference between ready queue and waiting queue
    public void WaitMethod(object state)
    {
      lock (this)
      {
        for (int i = 0; i < 1000000; ++i)
          ++LockedNumber;
        System.Threading.Monitor.Wait(this);
        for (int i = 0; i < 2000000; ++i)
          --LockedNumber;
      }
    }
    public void PulseMethod(object state)
    {
      lock (this)
      {
        for (int i = 0; i < 1000000; ++i)
          ++LockedNumber;
        System.Threading.Monitor.Pulse(this);
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
        DataProcessingSimulator();
    }
    private void DataProcessingSimulator()
    {
      for (int i = 0; i < 1000000; i++)
      {
        int _value = m_Random.Next(0, 10000);
        m_IntegerA = _value;
        m_IntegerB = -_value;
        IsConsistent &= m_IntegerA + m_IntegerB == 0;
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
