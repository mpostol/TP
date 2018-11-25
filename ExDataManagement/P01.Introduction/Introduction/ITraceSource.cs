//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Diagnostics;

namespace TP.Introduction
{
  /// <summary>
  /// Interface ITraceSource - defines trace source.
  /// </summary>
  public interface ITraceSource
  {

    /// <summary>
    /// Writes trace data to the trace listeners in the <see cref="System.Diagnostics.TraceSource.Listeners"/> collection using the specified <paramref name="eventType"/>, 
    /// event identifier <paramref name="id"/>, and trace <paramref name="data"/>.
    /// </summary>
    /// <param name="eventType">One of the enumeration values that specifies the event type of the trace data.</param>
    /// <param name="id">A numeric identifier for the event.</param>
    /// <param name="data">The trace data.</param>
    /// An attempt was made to trace an event during finalization.
    /// </exception>
    void TraceData(TraceEventType eventType, int id, object data);

  }
}
