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
  /// <summary>
  /// Code sample to examine data consistence in th concurrent programming environment
  /// </summary>
  public class CriticalSection
  {
    #region Monitor methods

    public void NoProtectedMethod(object? state)
    {
      CommonDataProcessingSimulator();
    }

    public void ProtectedMethod(object? state)
    {
      bool lockWasTaken = false;
      try
      {
        Monitor.Enter(this, ref lockWasTaken);
        if (!lockWasTaken)
          throw new ArgumentException();
        CommonDataProcessingSimulator();
      }
      finally
      {
        if (lockWasTaken)
          Monitor.Exit(this);
      }
    }

    #endregion Monitor methods

    #region private

    private int m_IntegerA = 0;
    private int m_IntegerB = 0;
    private Random m_Random = new Random();

    private void CommonDataProcessingSimulator()
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
    public bool IsConsistent = true;

    #endregion UT Instrumentation
  }
}