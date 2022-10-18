//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;

namespace TP.InformationComputation.LayersCommunication.Logic
{
  public interface ITracingContext
  {
    /// <summary>
    /// One of the enumeration values defined by the <see cref="TraceEventType"/> type that specifies the event type of the trace data.
    /// </summary>
    TraceEventType eventType { get; }

    /// <summary>
    /// A numeric identifier for the event.
    /// </summary>
    int id { get; }

    /// <summary>
    /// The trace data.
    /// </summary>
    object data { get; }
  }

  internal abstract class ReactiveProgramming : IReactiveProgramming
  {
    #region constructor

    public ReactiveProgramming()
    {
      eventObservable = Observable.FromEventPattern<TraceEventArgs>(this, "publish");
    }

    #endregion constructor

    #region ILogic

    public void Alpha()
    {
      publish?.Invoke(this, new TraceEventArgs(new TracingContext(TraceEventType.Verbose, nameof(Alpha).GetHashCode(), "Entering Alpha")));
    }

    public void Bravo()
    {
      publish?.Invoke(this, new TraceEventArgs(new TracingContext(TraceEventType.Verbose, nameof(Bravo).GetHashCode(), "Entering Bravo")));
    }

    public void Charlie()
    {
      publish?.Invoke(this, new TraceEventArgs(new TracingContext(TraceEventType.Verbose, nameof(Charlie).GetHashCode(), "Entering Charlie")));
    }

    public void Delta()
    {
      publish?.Invoke(this, new TraceEventArgs(new TracingContext(TraceEventType.Verbose, nameof(Delta).GetHashCode(), "Entering Delta")));
    }

    #endregion ILogic

    #region IObservable<TracingContext>

    public IDisposable Subscribe(IObserver<ITracingContext> observer)
    {
      return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Context), ex => observer.OnError(ex), () => observer.OnCompleted());
    }

    #endregion IObservable<TracingContext>

    #region private

    /// <summary>
    /// Represents a custom class that contain event data, and provides a value to use for events that do not include event data.
    /// </summary>
    public class TraceEventArgs : EventArgs
    {
      /// <summary>
      /// Creates an instance of the <see cref="TraceEventArgs"/>
      /// </summary>
      /// <param name="context"></param>
      public TraceEventArgs(ITracingContext context)
      {
        Context = context;
      }

      public ITracingContext Context { get; set; }
    }

    public event EventHandler<TraceEventArgs>? publish;

    private class TracingContext : ITracingContext
    {
      public TracingContext(TraceEventType eventType, int id, string data)
      {
        this.eventType = eventType;
        this.id = id;
        this.data = data;
      }

      public TraceEventType eventType { get; private set; }
      public int id { get; private set; }
      public object data { get; private set; }
    }

    private IObservable<EventPattern<TraceEventArgs>> eventObservable;

    #endregion private
  }
}