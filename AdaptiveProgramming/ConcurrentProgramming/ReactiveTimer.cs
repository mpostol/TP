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
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  public class TickEventArgs : EventArgs
  {
    // Lets notify current counter to subscribers
    public TickEventArgs(long counter)
    {
      Counter = counter;
    }

    public long Counter
    {
      get;
      private set;
    }
  }

  public class ReactiveTimer : IDisposable
  {
    #region constructor

    public ReactiveTimer(TimeSpan period)
    {
      Period = period;
    }

    #endregion constructor

    #region API

    public event EventHandler<TickEventArgs> Tick;

    //What happens after recalling Start ??
    public void Start()
    {
      // Create observable when needed
      IObservable<long> _TimerObservable = Observable.Interval(Period);
      m_TimerSubscription = _TimerObservable.ObserveOn(Scheduler.Default).Subscribe(c => RaiseTick(c));
      //m_TimerSubscription = _TimerObservable.ObserveOn(DispatcherScheduler.Current).Subscribe(c => RaiseTick(c));
    }

    public TimeSpan Period
    {
      get;
      private set;
    }

    #endregion API

    #region private

    private IDisposable m_TimerSubscription = null;

    private void RaiseTick(long counter)
    {
      // Make safe call
      Tick?.Invoke(this, new TickEventArgs(counter));
    }

    #region IDisposable Support

    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: dispose managed state (managed objects).
        }
        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.
        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~Timer() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }

    #endregion IDisposable Support

    #endregion private
  }
}