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

namespace TP.InformationComputation.DependencyInjection
{
  /// <summary>
  /// Class ConsoleTraceSource - an example implementation of <see cref="ITraceSource"/> using <see cref="Console"/> to trace code behavior.
  /// </summary>
  /// <seealso cref="ITraceSource" />
  internal class ConsoleTraceSource : ITraceSource
  {
    /// <summary>
    /// Writes trace data to the trace listeners in the <see cref="P:System.Diagnostics.TraceSource.Listeners" /> collection using the specified <paramref name="eventType" />,
    /// event identifier <paramref name="id" />, and trace <paramref name="data" />.
    /// </summary>
    /// <param name="eventType">One of the enumeration values that specifies the event type of the trace data.</param>
    /// <param name="id">A numeric identifier for the event.</param>
    /// <param name="data">The trace data.</param>
    public void TraceData(TraceEventType eventType, int id, object data)
    {
      Console.WriteLine($"Event type: {eventType}, id: {id}, message: {data}");
    }
  }
}