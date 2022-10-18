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
  public class DependencyInjectionUsage
  {
    [TestMethod]
    public void PropertyInjectionAfterCreationStateTest()
    {
      IPropertyInjection propertyInjection = ILogicAbstraction.NewPropertyInjection();
      Assert.IsNull(propertyInjection.TraceSource);
    }

    [TestMethod]
    public void PropertyInjectionTest()
    {
      InMemoryTraceSource traceSource = new InMemoryTraceSource();
      IPropertyInjection propertyInjection = ILogicAbstraction.NewPropertyInjection();
      propertyInjection.TraceSource = traceSource;
      propertyInjection.Alpha();
      propertyInjection.Bravo();
      propertyInjection.Charlie();
      propertyInjection.Delta();
      traceSource.CheckConsistency();
      propertyInjection.TraceSource = new DoNothingTraceSource(); //It is possible to inject new object of a different type.
      propertyInjection.Alpha();
      propertyInjection.Bravo();
      propertyInjection.Charlie();
      propertyInjection.Delta();
      traceSource.CheckConsistency();
    }

    [TestMethod]
    public void ConstructorInjectionTest()
    {
      InMemoryTraceSource traceSource = new InMemoryTraceSource();
      ILogic _ConstructorInjection = ILogicAbstraction.NewConstructorInjection(traceSource);
      _ConstructorInjection.Alpha();
      _ConstructorInjection.Bravo();
      _ConstructorInjection.Charlie();
      _ConstructorInjection.Delta();
      traceSource.CheckConsistency();
    }
  }
}