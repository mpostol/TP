
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.Lecture.Reflection;

namespace TP.Lecture.UnitTest.Reflection
{
  [TestClass]
  public class ModelUnitTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      AssemblyModel _ass = new AssemblyModel();
      Assert.IsNotNull(_ass);
    }
  }
}
