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

namespace TP.InformationComputation.LayersCommunication.Logic
{
  public struct TraceData
  {
    public TraceData(TraceEventType eventType, int id, string message)
    {
      EventType = eventType;
      ID = id;
      Message = message;
    }

    public TraceEventType EventType { get; private set; }
    public int ID { get; private set; }
    public string Message { get; private set; }
  }

  /// <summary>
  /// An example of functionality associated with an event-based tracing mechanism.
  /// </summary>
  public interface IEventBased : ILogic
  {
    /// <summary>
    /// This <see cref="TraceDataEvent"/> event should be triggered every time the method defined by this interface is called.
    /// </summary>
    event EventHandler<TraceData> TraceDataEvent;
  }
}