//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.DependencyInjection.Instrumentation;

namespace TP.InformationComputation.DependencyInjection
{
  [TestClass]
  public class ConstructorInjectionTest
  {
    [TestMethod]
    public void ConstructorInjectionTestMethod()
    {
      InMemoryTraceSource inMemoryTraceSourceInstance = new InMemoryTraceSource();
      ConstructorInjection _ConstructorInjection = new ConstructorInjection(inMemoryTraceSourceInstance);
      _ConstructorInjection.Alpha();
      Assert.AreEqual<int>(1, inMemoryTraceSourceInstance._callStack.Count);
      _ConstructorInjection.Bravo();
      Assert.AreEqual<int>(2, inMemoryTraceSourceInstance._callStack.Count);
      _ConstructorInjection.Charlie();
      Assert.AreEqual<int>(3, inMemoryTraceSourceInstance._callStack.Count);
      _ConstructorInjection.Delta();
      Assert.AreEqual<int>(4, inMemoryTraceSourceInstance._callStack.Count);
      inMemoryTraceSourceInstance.CheckConsistency();
    }
  }
}