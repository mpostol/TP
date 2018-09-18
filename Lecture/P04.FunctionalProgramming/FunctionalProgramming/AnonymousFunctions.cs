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

  public enum State { Stanby, Working, Error };
  public interface IStateHandler
  {
    State CurrentState { get; }
    void GoToStanby();
    void GoToWorking();
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

    #region state machine context
    public AnonymousFunctions()
    {
      CurrentState = new StanbyHandler(this);
    }
    public IStateHandler CurrentState { get; private set; }
    public event EventHandler<State> OnStateChanged;
    #endregion

    #region test instrumentation
    internal delegate void CallBackTestDelegate(bool testResult);
    [Conditional("DEBUG")]
    internal void ConsistencyCheck(CallBackTestDelegate testResult)
    {
      testResult(true);
    }
    #endregion

    #region states implementation
    private abstract class StateHandlerBase : IStateHandler
    {
      public StateHandlerBase(AnonymousFunctions context)
      {
        context.CurrentState = this;
        context.OnStateChanged?.Invoke(context, CurrentState);
      }
      public abstract State CurrentState { get; }
      public virtual void GoToError()
      {
        throw new System.NotImplementedException();
      }
      public virtual void GoToStanby()
      {
        throw new System.NotImplementedException();
      }
      public virtual void GoToWorking()
      {
        throw new System.NotImplementedException();
      }
      protected readonly AnonymousFunctions m_Context;
    }
    private class StanbyHandler : StateHandlerBase
    {
      public StanbyHandler(AnonymousFunctions context) : base(context) { }
      public override State CurrentState => State.Stanby;
      public override void GoToWorking()
      {
        new WorkingHandler(base.m_Context);
      }
    }
    private class WorkingHandler : StateHandlerBase
    {
      public WorkingHandler(AnonymousFunctions context) : base(context) { }
      public override State CurrentState => State.Working;
      public override void GoToError()
      {
        new ErrorHandler(base.m_Context);
      }
      public override void GoToStanby()
      {
        new StanbyHandler(base.m_Context);
      }
    }
    private class ErrorHandler : StateHandlerBase
    {
      public ErrorHandler(AnonymousFunctions context) : base(context) { }
      public override State CurrentState => State.Error;
      public override void GoToStanby()
      {
        new StanbyHandler(base.m_Context);
      }
    }
    #endregion

  }
}
