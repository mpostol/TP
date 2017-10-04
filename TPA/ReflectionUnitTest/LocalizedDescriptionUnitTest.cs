
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Reflection.UnitTest
{
  [TestClass]
  public class LocalizedDescriptionUnitTest
  {
    [TestMethod]
    public void TestMethod()
    {
      Assert.Inconclusive();
    }

    private class TestInstrumentation
    {
      [LocalizedDescription("Description")]
      public int MyProperty { get; set; }
    }
  }
}
