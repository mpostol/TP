
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.Lecture.UnitTest
{
  /// <summary>
  /// Class FromClauseUnitTest - unit tests for <see cref="FromClause"/>
  /// </summary>

  [TestClass]
  public class LinqExtensionsUnitTest
  {

    [TestMethod]
    public void LinqExtensionsExample1TestMethod()
    {
      LinqExtensions _fc = new LinqExtensions();
      Assert.AreEqual<string>("grape", _fc.FromClauseExample1());
    }

    [TestMethod]
    public void LinqExtensionsExample2TestMethod()
    {
      LinqExtensions _fc = new LinqExtensions();
      Assert.AreEqual<string>("grape", _fc.FromClauseExample2());
    }

    [TestMethod]
    public void LinqExtensionsExample3TestMethod()
    {
      LinqExtensions _fc = new LinqExtensions();
      Assert.AreEqual<string>("Name1:11000,00;Name3:130000,00", _fc.FromClauseExample3());
    }

  }
}

