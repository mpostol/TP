using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.DependencyInjection.UnitTest.Instrumentation;

namespace TP.DependencyInjection.UnitTest
{
  [TestClass]
  public class PropertyInjectionUnitTest
  {
    [TestMethod]
    public void AfterCreationStateTestMethod()
    {
      PropertyInjection _PropertyInjection = new PropertyInjection();
      Assert.IsNull(_PropertyInjection.TraceSource);
    }
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void NoTracerDefinedTestMethod()
    {
      PropertyInjection _PropertyInjection = new PropertyInjection();
      _PropertyInjection.Alpha();
    }
    [TestMethod]
    public void PropertyInjectionTest()
    {
      InMemoryTraceSource _TraceSource = new InMemoryTraceSource();
      PropertyInjection _ConstructorInjection = new PropertyInjection() { TraceSource = _TraceSource };
      _ConstructorInjection.Alpha();
      Assert.AreEqual<int>(1, _TraceSource._callStack.Count);
      _ConstructorInjection.Bravo();
      Assert.AreEqual<int>(2, _TraceSource._callStack.Count);
      _ConstructorInjection.Charlie();
      Assert.AreEqual<int>(3, _TraceSource._callStack.Count);
      _ConstructorInjection.Delta();
      Assert.AreEqual<int>(4, _TraceSource._callStack.Count);
      _TraceSource.CheckConsistency();
      _ConstructorInjection.TraceSource = new DoNothingTraceSource();
      _ConstructorInjection.Alpha();
      _ConstructorInjection.Bravo();
      _ConstructorInjection.Charlie();
      _ConstructorInjection.Delta();
      Assert.AreEqual<int>(4, _TraceSource._callStack.Count);
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
