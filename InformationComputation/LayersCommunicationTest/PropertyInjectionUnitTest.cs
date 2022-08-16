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
using TP.InformationComputation.LayersCommunication.Instrumentation;
using TP.InformationComputation.LayersCommunication.Logic;

namespace TP.InformationComputation.LayersCommunication
{
  [TestClass]
  public class PropertyInjectionUnitTest
  {
    [TestMethod]
    public void AfterCreationStateTestMethod()
    {
      PropertyInjection propertyInjection = new PropertyInjection();
      Assert.IsNull(propertyInjection.TraceSource);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void NoTracerDefinedTestMethod()
    {
      PropertyInjection propertyInjection = new PropertyInjection();
      propertyInjection.Alpha();
    }

    [TestMethod]
    public void PropertyInjectionTest()
    {
      InMemoryTraceSource traceSource = new InMemoryTraceSource();
      PropertyInjection propertyInjection = new PropertyInjection() { TraceSource = traceSource };
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

    private class DoNothingTraceSource : ITraceSource
    {
      public void TraceData(TraceEventType eventType, int id, object data)
      {
        //Do nothing
      }
    }
  }
}