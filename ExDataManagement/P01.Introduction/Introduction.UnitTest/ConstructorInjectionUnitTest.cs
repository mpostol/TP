//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.Introduction.Instrumentation;

namespace TP.Introduction
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
