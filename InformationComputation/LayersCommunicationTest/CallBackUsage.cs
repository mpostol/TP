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
  public class CallBackUsage
  {
    [TestMethod]
    public void CallBackTestMethod()
    {
      InMemoryTraceSource inMemoryTraceSource = new InMemoryTraceSource();
      ICallBack callBackBased = ILogicAbstraction.NewICallBack();
      callBackBased.Alpha(inMemoryTraceSource.TraceData);
      callBackBased.Bravo(inMemoryTraceSource.TraceData);
      callBackBased.Charlie(inMemoryTraceSource.TraceData);
      callBackBased.Delta(inMemoryTraceSource.TraceData);
      inMemoryTraceSource.CheckConsistency();
    }
  }
}