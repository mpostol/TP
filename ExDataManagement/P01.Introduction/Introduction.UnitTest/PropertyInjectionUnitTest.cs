//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using TP.Introduction.Instrumentation;

namespace TP.Introduction
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