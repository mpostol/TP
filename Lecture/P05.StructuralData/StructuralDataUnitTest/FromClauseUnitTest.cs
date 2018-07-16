
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.Lecture.UnitTest
{
  /// <summary>
  /// Class FromClauseUnitTest - unit tests for <see cref="FromClause"/>
  /// </summary>

  [TestClass]
  public class FromClauseUnitTest
  {

    [TestMethod]
    public void FromClauseExample1TestMethod()
    {
      FromClause _fc = new FromClause();
      Assert.AreEqual<string>("grape", _fc.FromClauseExample1());
    }

    [TestMethod]
    public void FromClauseExample2TestMethod()
    {
      FromClause _fc = new FromClause();
      Assert.AreEqual<string>("grape", _fc.FromClauseExample2());
    }

    [TestMethod]
    public void FromClauseExample3TestMethod()
    {
      FromClause _fc = new FromClause();
      Assert.AreEqual<string>("Name1:11000,00;Name3:130000,00", _fc.FromClauseExample3());
    }

  }
}

