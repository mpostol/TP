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

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPD.AsynchronousProgramming
{
  public class CriticalSectionExample
  {
    #region public API

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
          _tasksInProgress.Add(Task.Run(() => ThreadFuncWithMonitor(null)));
        else
          _tasksInProgress.Add(Task.Run(() => ThreadFunc(null)));
      //wait for threads
      Task.WaitAll(_tasksInProgress.ToArray());
    }

    #endregion public API

    #region private

    private readonly object m_SyncObject = new object();
    private int m_IntegerA = 0;
    private int m_IntegerB = 0;
    private Random m_Random = new Random();
    private bool m_IsConsistent = true;

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
        Thread.Sleep(0);
        m_IsConsistent &= m_IntegerA + m_IntegerB == 0;
      }
    }

    #endregion private

    #region UT Instrumentation

    /// <summary>
    /// Gets a value indicating whether this instance is consistent.
    /// </summary>
    /// <remarks>Always shall return <c>true</c>.</remarks>
    [System.Diagnostics.Conditional("DEBUG")]
    public void GetConsistent(Action<bool> callback)
    {
      callback(m_IsConsistent);
    }

    #endregion UT Instrumentation
  }
}