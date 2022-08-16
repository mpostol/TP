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

  internal class ReactiveProgrammingPublisher : IObservable<ITracingContext>
  {
    public ReactiveProgrammingPublisher()
    {
      eventObservable = Observable.FromEventPattern<TraceEventArgs>(this, "publish");
    }

    #region IObservable<TracingContext>

    public IDisposable Subscribe(IObserver<ITracingContext> observer)
    {
      return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Context), ex => observer.OnError(ex), () => observer.OnCompleted());
    }

    #endregion IObservable<TracingContext>

    public event EventHandler<TraceEventArgs>? publish;

    private class TracingContext : ITracingContext
    {
      public TraceEventType eventType { get; set; }
      public int id { get; set; }
      public object data { get; set; }
    }

    private IObservable<EventPattern<TraceEventArgs>> eventObservable = null;
  }
}