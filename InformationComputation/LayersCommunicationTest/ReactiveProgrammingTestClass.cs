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
  public class ReactiveProgrammingTestClass
  {
    [TestMethod]
    public void ReactiveProgrammingTestMethod()
    {
      InMemoryTraceSource tracer = new InMemoryTraceSource();
      IReactiveProgramming reactiveProgramming = LogicAbstraction.NewReactiveProgramming();
      reactiveProgramming.Subscribe(x => tracer.TraceData(x.eventType, x.id, x.data));
      reactiveProgramming.Alpha();
      reactiveProgramming.Bravo();
      reactiveProgramming.Charlie();
      reactiveProgramming.Delta();
    }
  }
}