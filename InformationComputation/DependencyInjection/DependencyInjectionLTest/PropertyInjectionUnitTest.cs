//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
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
  public class PropertyInjectionUnitTest
  {
    [TestMethod]
    public void AfterCreationStateTestMethod()
    {
      PropertyInjection propertyInjection = new PropertyInjection();
      Assert.IsNull(propertyInjection.TraceSource);
      propertyInjection.Alpha();
      propertyInjection.Bravo();
      propertyInjection.Charlie();
      propertyInjection.Delta();
      propertyInjection.TraceSource = new DoNothingTraceSource();
      propertyInjection.Delta();
      propertyInjection.Bravo();
      propertyInjection.Charlie();
      propertyInjection.Alpha();
    }

    [TestMethod]
    public void PropertyInjectionTest()
    {
      InMemoryTraceSource inMemoryTraceSourceInstance = new InMemoryTraceSource();
      PropertyInjection propertyInjection = new PropertyInjection() { TraceSource = inMemoryTraceSourceInstance };
      propertyInjection.Alpha();
      Assert.AreEqual<int>(1, inMemoryTraceSourceInstance._callStack.Count);
      propertyInjection.Bravo();
      Assert.AreEqual<int>(2, inMemoryTraceSourceInstance._callStack.Count);
      propertyInjection.Charlie();
      Assert.AreEqual<int>(3, inMemoryTraceSourceInstance._callStack.Count);
      propertyInjection.Delta();
      Assert.AreEqual<int>(4, inMemoryTraceSourceInstance._callStack.Count);
      inMemoryTraceSourceInstance.CheckConsistency();
    }
  }
}