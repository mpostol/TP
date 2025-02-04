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

using System.Diagnostics;

namespace TP.ConcurrentProgramming.Fundamentals.Test
{
  [TestClass]
  public class HoareMonitorConditionTest
  {
    [TestMethod]
    public void CreateConditionTest()
    {
      //prepare
      bool result = false;
      using (HoareMonitorFixture hoareMonitorFixture = new HoareMonitorFixture())
      {
        //act
        hoareMonitorFixture.CreateICondition();
        hoareMonitorFixture.IsConsistent(x => result = x);
        //test
        Assert.IsTrue(result);
      }
    }

    [TestMethod]
    public void WaitTest()
    {
      //prepare
      bool result = false;
      bool isEntered = true;
      using (HoareMonitorFixture hoareMonitorFixture = new HoareMonitorFixture())
      {
        //act
        hoareMonitorFixture.CreateICondition();
        Thread additionalthreads = new Thread(
          () =>
          {
            hoareMonitorFixture.HoldsMonitor(x => isEntered = x);
            hoareMonitorFixture.WauitICondition();
          }
        );
        additionalthreads.Start();
        Thread.Sleep(500);
        hoareMonitorFixture.IsConsistent(x => result = x);
      }
      //test
      Assert.IsTrue(result);
      Assert.IsFalse(isEntered);
    }

    [TestMethod]
    public void SendTest()
    {
      //prepare
      bool result = true;
      bool WaitingThreadisEntered = true;
      using (HoareMonitorFixture hoareMonitorFixture = new HoareMonitorFixture())
      {
        //act
        hoareMonitorFixture.CreateICondition();
        Thread additionalthreads = new Thread(
          () =>
          {
            hoareMonitorFixture.HoldsMonitor(x => WaitingThreadisEntered = x);
            hoareMonitorFixture.WauitICondition();
          }
        );
        additionalthreads.Start();
        Thread.Sleep(500);
        hoareMonitorFixture.IsConsistent(x => result &= x);
        hoareMonitorFixture.SendCondition();
        additionalthreads.Join(); 
      }
      //test
      Assert.IsTrue(result);
      Assert.IsFalse(WaitingThreadisEntered);
    }

    [TestMethod]
    public void SendBeforeWaitTest()
    {
      //prepare
      bool result = true;
      bool WaitingThreadisEntered = true;
      using (HoareMonitorFixture hoareMonitorFixture = new HoareMonitorFixture())
      {
        //act
        hoareMonitorFixture.CreateICondition();
        hoareMonitorFixture.SendCondition();
        Thread additionalthreads = new Thread(
          () =>
          {
            hoareMonitorFixture.HoldsMonitor(x => WaitingThreadisEntered = x);
            hoareMonitorFixture.WauitICondition();
          }
        );
        additionalthreads.Start();
        Thread.Sleep(500);
        hoareMonitorFixture.IsConsistent(x => result &= x);
      }
      //test
      Assert.IsTrue(result);
      Assert.IsFalse(WaitingThreadisEntered);
    }

    #region test instrumentation

    private class HoareMonitorFixture : HoareMonitor
    {
      private ICondition? m_Condition = null;

      internal void CreateICondition()
      {
        EnterMonitor();
        try
        {
          m_Condition = CreateCondition();
          m_IsConsistent = m_Condition != null;
        }
        finally
        {
          ExitMonitor();
        }
      }

      internal void WauitICondition()
      {
        EnterMonitor();
        try
        {
          m_IsConsistent = m_Condition != null;
          HoldsMonitor(x => m_IsConsistent = m_IsConsistent && x);
          m_Condition?.Wait();
        }
        finally
        {
          ExitMonitor();
        }
      }

      internal void SendCondition()
      {
        EnterMonitor();
        try
        {
          m_IsConsistent = m_Condition != null;
          HoldsMonitor(x => m_IsConsistent = m_IsConsistent && x);
          m_Condition?.Send();
        }
        finally
        {
          ExitMonitor();
        }
      }

      #region DEBUG instrumentation

      private bool m_IsConsistent = false;

      [Conditional("DEBUG")]
      internal void HoldsMonitor(Action<bool> action)
      {
        bool result = false;
        IsEntered(x => result = x);
        action(result);
      }

      [Conditional("DEBUG")]
      internal void IsConsistent(Action<bool> action)
      {
        action(m_IsConsistent);
      }

      protected override ISignal CreateSignal()
      {
        throw new NotImplementedException();
      }

      #endregion DEBUG instrumentation
    }

    #endregion test instrumentation
  }
}