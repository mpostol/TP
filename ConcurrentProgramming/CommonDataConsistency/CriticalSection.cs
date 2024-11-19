//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.CommonDataConsistency
{
  public class CriticalSection
  {
    #region Monitor methods

    public int LockedNumber; // variable used to demonstrate how monitors works

    public void NoMonitorMethod(object state)
    {
      DataProcessingSimulator();
    }

    public void MonitorMethod(object state)
    {
      bool lockWasTaken = false;
      try
      {
        Monitor.Enter(this, ref lockWasTaken);
        if (!lockWasTaken)
          throw new ArgumentException();
        DataProcessingSimulator();
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

    #endregion Monitor methods

    #region private

    private readonly object m_SyncObject = new object();
    private int m_IntegerA = 0;
    private int m_IntegerB = 0;
    private Random m_Random = new Random();

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

    #endregion private

    #region UT Instrumentation

    /// <summary>
    /// Gets a value indicating whether this instance is consistent.
    /// </summary>
    /// <remarks>Always must be true.</remarks>
    /// <value><c>true</c> if this instance is consistent; otherwise, <c>false</c>.</value>
    public bool IsConsistent { get; private set; } = true;

    #endregion UT Instrumentation
  }
}