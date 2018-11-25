
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
