
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.CodeGeneration;

namespace TPA.Reflection.UnitTest.CodeGeneration
{
  [TestClass]
  public class DynamicMethodFactoryUnitTest
  {

    [TestMethod]
    public void DynamicMethodFactoryTest()
    {
#if !DEBUG
      Assert.Fail("Test must run in DEBU solution configuration");
#endif
      DynamicMethodFactory _newFactory = new DynamicMethodFactory();
      bool _consitency = false;
      _newFactory.TestConsitency(x => _consitency = x);
      Assert.IsTrue(_consitency);
      Assert.AreEqual<long>(15241578750190521, _newFactory.DynamicMethodCall(123456789));
    }

  }
}
