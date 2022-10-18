//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayersCommunication.Instrumentation;
using TP.InformationComputation.LayersCommunication.Logic;

namespace TP.InformationComputation.LayersCommunication
{
  [TestClass]
  public class EventBasedUsage
  {
    [TestMethod]
    public void EventBasedTestMethod()
    {
      InMemoryTraceSource inMemoryTrace = new InMemoryTraceSource();
      IEventBased eventBased = ILogicAbstraction.NewEventBased();
      eventBased.TraceDataEvent += inMemoryTrace.TraceData;
      eventBased.Alpha();
      eventBased.Bravo();
      eventBased.Charlie();
      eventBased.Delta();
      inMemoryTrace.CheckConsistency();
    }
  }
}