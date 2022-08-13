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
using TP.InformationComputation.LayersCommunication.Logic.DependencyInjection;

namespace TP.InformationComputation.LayersCommunication
{
  [TestClass]
  public class ConstructorInjectionUnitTest
  {
    [TestMethod]
    public void ConstructorInjectionTest()
    {
      InMemoryTraceSource _TraceSource = new InMemoryTraceSource();
      ConstructorInjection _ConstructorInjection = new ConstructorInjection(_TraceSource);
      _ConstructorInjection.Alpha();
      Assert.AreEqual<int>(1, _TraceSource._callStack.Count);
      _ConstructorInjection.Bravo();
      Assert.AreEqual<int>(2, _TraceSource._callStack.Count);
      _ConstructorInjection.Charlie();
      Assert.AreEqual<int>(3, _TraceSource._callStack.Count);
      _ConstructorInjection.Delta();
      Assert.AreEqual<int>(4, _TraceSource._callStack.Count);
      _TraceSource.CheckConsistency();
    }
  }
}