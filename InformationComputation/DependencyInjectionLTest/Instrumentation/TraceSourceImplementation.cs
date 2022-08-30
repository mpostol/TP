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

namespace TP.InformationComputation.DependencyInjection.Instrumentation
{
  internal class InMemoryTraceSource : ITraceSource
  {
    public void TraceData(TraceEventType eventType, int id, object data)
    {
      _callStack.Add(id);
    }

    internal void CheckConsistency()
    {
      Assert.AreEqual<int>(4, _callStack.Count);
      Assert.AreEqual<int>("Alpha".GetHashCode(), _callStack[0]);
      Assert.AreEqual<int>("Bravo".GetHashCode(), _callStack[1]);
      Assert.AreEqual<int>("Charlie".GetHashCode(), _callStack[2]);
      Assert.AreEqual<int>("Delta".GetHashCode(), _callStack[3]);
    }

    internal List<int> _callStack = new List<int>();
  }
  internal class DoNothingTraceSource : ITraceSource
  {
    public void TraceData(TraceEventType eventType, int id, object data)
    {
      //Do nothing
    }
  }
}
