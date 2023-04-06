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

using System.Diagnostics;

namespace TPD.AsynchronousProgramming
{
  /// <summary>
  /// Interface ITraceSource - declares basic functionality for the component behavior tracing.
  /// </summary>
  public interface ITraceSource
  {
    /// <summary>
    /// a trace event message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified event type and event identifier.
    /// </summary>
    /// <param name="eventType">One of the enumeration values that specifies the event type of the trace data.</param>
    /// <param name="id">A numeric identifier for the event.</param>
    /// <param name="message"> The trace message to write.</param>
    /// <exception cref="T:System.ObjectDisposedException">An attempt was made to trace an event during finalization.</exception>
    void TraceMessage(TraceEventType eventType, int id, string message);
  }
}