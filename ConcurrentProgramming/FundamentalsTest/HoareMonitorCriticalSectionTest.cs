//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Fundamentals.Test
{
  [TestClass]
  public class HoareMonitorCriticalSectionTest
  {
    [TestMethod]
    public void HoareProtectedMethodCallTest()
    {
      //prepare
      CriticalSectionFixture criticalSectionFixture = new CriticalSectionFixture();
      //act
      RunConcurrentlyManuallyCreatedThreads(criticalSectionFixture.CriticalSectionWorkingMethod);
      //test
      Assert.IsTrue(criticalSectionFixture.IsConsistent);
      //cleanup
      criticalSectionFixture.Dispose();
    }

    #region test instrumentation

    private void RunConcurrentlyManuallyCreatedThreads(ParameterizedThreadStart start)
    {
      Thread[] threadsArray = new Thread[2];
      for (int i = 0; i < threadsArray.Length; i++)
        threadsArray[i] = new Thread(start);
      foreach (Thread _thread in threadsArray)
        _thread.Start();
      foreach (Thread _thread in threadsArray)
        _thread.Join();
    }

    private class CriticalSectionFixture : HoareMonitor
    {
      #region Monitor methods

      public void CriticalSectionWorkingMethod(object? state)
      {
        EnterMonitor();
        try
        {
          CommonDataProcessingSimulator();
        }
        finally
        {
          ExitMonitor();
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

      protected override ISignal CreateSignal()
      {
        throw new NotImplementedException();
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

    #endregion test instrumentation
  }
}