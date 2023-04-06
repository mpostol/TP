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