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
using TP.InformationComputation.LayersCommunication.Logic;

namespace TP.InformationComputation.LayersCommunication.Instrumentation
{
  internal class InMemoryTraceSource : ITraceSource
  {
    public void TraceData(TraceEventType eventType, int id, object data)
    {
      CallStack.Add(id);
    }

    /// <summary>
    /// Represents the method that will handle an event when the event provides data.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An object that contains the event data.</param>
    internal void TraceData(object? sender, TraceData e)
    {
      TraceData(e.EventType, e.ID, e.Message);
    }

    internal void CheckConsistency()
    {
      Assert.AreEqual<int>(4, CallStack.Count);
      Assert.AreEqual<int>("Alpha".GetHashCode(), CallStack[0]);
      Assert.AreEqual<int>("Bravo".GetHashCode(), CallStack[1]);
      Assert.AreEqual<int>("Charlie".GetHashCode(), CallStack[2]);
      Assert.AreEqual<int>("Delta".GetHashCode(), CallStack[3]);
    }

    private List<int> CallStack = new();
  }
}