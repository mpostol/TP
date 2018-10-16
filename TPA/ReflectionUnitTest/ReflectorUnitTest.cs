using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Reflection.UnitTest
{
  [TestClass]
  public class ReflectorUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      Assert.ThrowsException<ArgumentNullException>(() => new Reflector(""));
    }
  }
}
