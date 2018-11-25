//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Diagnostics;

namespace TP.FunctionalProgramming
{

  public enum State { Idle, Active, Error };
  public interface IStateHandler
  {
    State CurrentState { get; }
    void GoToIdle();
    void GoToActive();
    void GoToError();
  }
  public class AnonymousFunctions
  {

    #region predicate
    public static bool StringIsLongPredicate(string stringToTest)
    {
      return stringToTest.Length > 10;
    }
    #endregion

    #region test instrumentation
    internal delegate void CallBackTestDelegate(bool testResult);
    [Conditional("DEBUG")]
    internal void ConsistencyCheck(CallBackTestDelegate testResult)
    {
      testResult(CurrentStateHandler != null);
    }
    #endregion

    #region state machine context
    public AnonymousFunctions()
    {
      CurrentStateHandler = new IdleHandler(this);
    }
    public IStateHandler CurrentStateHandler { get; private set; }
    public event EventHandler<State> OnStateChanged;
    #endregion

    #region states implementation
    private abstract class StateHandlerBase : IStateHandler
    {
      public StateHandlerBase(AnonymousFunctions context)
      {
        m_Context = context;
        m_Context.CurrentStateHandler = this;
        m_Context.OnStateChanged?.Invoke(context, CurrentState);
      }
      public abstract State CurrentState { get; }
      public virtual void GoToError()
      {
        throw new System.NotImplementedException();
      }
      public virtual void GoToIdle()
      {
        throw new System.NotImplementedException();
      }
      public virtual void GoToActive()
      {
        throw new System.NotImplementedException();
      }
      protected readonly AnonymousFunctions m_Context;
    }
    private class IdleHandler : StateHandlerBase
    {
      public IdleHandler(AnonymousFunctions context) : base(context) { }
      public override State CurrentState => State.Idle;
      public override void GoToActive()
      {
        new ActiveHandler(base.m_Context);
      }
    }
    private class ActiveHandler : StateHandlerBase
    {
      public ActiveHandler(AnonymousFunctions context) : base(context) { }
      public override State CurrentState => State.Active;
      public override void GoToError()
      {
        new ErrorHandler(base.m_Context);
      }
      public override void GoToIdle()
      {
        new IdleHandler(base.m_Context);
      }
    }
    private class ErrorHandler : StateHandlerBase
    {
      public ErrorHandler(AnonymousFunctions context) : base(context) { }
      public override State CurrentState => State.Error;
      public override void GoToIdle()
      {
        new IdleHandler(base.m_Context);
      }
    }
    #endregion

  }
}
