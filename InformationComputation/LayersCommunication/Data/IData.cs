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

namespace TP.InformationComputation.LayersCommunication.Data
{
  public interface IData
  {
    void InMemoryTraceData(TraceEventType eventType, int id, object data);

    bool CheckConsistency();

    /// <summary>
    /// Calling this method may be used to trace the behavior of the logic layer using the console.
    /// </summary>
    /// <remarks>
    /// Because it directly refers to the responsibility of the presentation layer calling this method should be avoided in all circumstances.
    /// Additionally, it refers to the rendering technology that may be not supported by the technology used by the presentation layer.
    /// Concluding, calling this method breaks the rules governing the program layered structure. This method is removed from further examination.
    /// </remarks>
    /// <param name="eventType"></param>
    /// <param name="id"></param>
    /// <param name="data"></param>
    void ConsoleTraceData(TraceEventType eventType, int id, object data);
  }
}