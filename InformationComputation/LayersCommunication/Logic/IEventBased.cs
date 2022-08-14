//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.LayersCommunication.Logic
{
  /// <summary>
  /// An example of functionality associated with an event-based tracing mechanism.
  /// </summary>
  public interface IEventBased
  {
    /// <summary>
    /// This <see cref="TraceDataEvent"/> event should be triggered every time the method defined by this interface is called.
    /// </summary>
    event TraceDataDelegate? TraceDataEvent;

    void Alpha();

    void Bravo();

    void Charlie();

    void Delta();
  }
}