//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.Diagnostics;

namespace TP.FunctionalProgramming
{
  public enum State
  { Idle, Active, Error };

  public interface IStateHandler
  {
    State CurrentState { get; }

    void GoToIdle();

    void GoToActive();

    void GoToError();
  }

  public class AnonymousFunctions
  {
    #region test instrumentation

    internal delegate void CallBackTestDelegate(bool testResult);

    /// <summary>
    /// Invoking this method the consistency of this state machine is checked.
    /// The result is transferred to the user through the <paramref name="testResult"/> delegate pointing
    /// out a method invoked to transfer the check result. While raising this delegate variable
    /// the null-conditional operator is not applied. Hence, this argument must not be null to prevent
    /// throwing an exception.
    /// </summary>
    /// <param name="testResult">This parameter contains a delegate value pointing out a method invoked
    /// to transfer the check result. This argument must not be null to prevent throwing an exception.
    /// </param>
    /// <exception cref="NullReferenceException">exception thrown if the <paramref name="testResult"/> evaluates to null.
    /// </exception>
    [Conditional("DEBUG")]
    internal void ConsistencyCheck(CallBackTestDelegate testResult)
    {
      testResult(CurrentStateHandler != null);
    }

    #endregion test instrumentation

    #region state machine context

    public AnonymousFunctions()
    {
      CurrentStateHandler = new IdleHandler(this);
    }

    public IStateHandler CurrentStateHandler { get; private set; }

    /// <summary>
    /// event declarations sample code
    /// </summary>
    public event EventHandler<State> OnStateChanged = null;

    #endregion state machine context

    #region states implementation

    private abstract class StateHandlerBase : IStateHandler
    {
      /// <summary>
      /// constructor of the <see cref="StateHandlerBase"/>
      /// </summary>
      /// <param name="context">source of event notification</param>
      public StateHandlerBase(AnonymousFunctions context)
      {
        m_Context = context;
        m_Context.CurrentStateHandler = this;
        m_Context.OnStateChanged?.Invoke(context, CurrentState); //Invocation of all the methods added to OnStateChanged, if any,
                                                                 //CurrentState contains the event data transfered to users.
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
      public IdleHandler(AnonymousFunctions context) : base(context)
      {
      }

      public override State CurrentState => State.Idle;

      public override void GoToActive()
      {
        new ActiveHandler(base.m_Context);
      }
    }

    private class ActiveHandler : StateHandlerBase
    {
      public ActiveHandler(AnonymousFunctions context) : base(context)
      {
      }

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
      public ErrorHandler(AnonymousFunctions context) : base(context)
      {
      }

      public override State CurrentState => State.Error;

      public override void GoToIdle()
      {
        new IdleHandler(base.m_Context);
      }
    }

    #endregion states implementation
  }
}