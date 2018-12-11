//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Logging.Consumer;

namespace TPA.Logging.UnitTest
{
  [TestClass]
  public class StaticTracingUnitTest
  {
    [TestMethod]
    public void StaticTracingTestMethod()
    {
      StaticTracing _traceUser = new StaticTracing();
      _traceUser.Processing();
    }
  }
}
