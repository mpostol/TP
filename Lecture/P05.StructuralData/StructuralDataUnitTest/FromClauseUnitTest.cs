//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
      Assert.AreEqual<string>("grape", FromClause.FromClauseExample1());
    }
    [TestMethod]
    public void FromClauseExample2TestMethod()
    {
      Assert.AreEqual<string>("grape", FromClause.FromClauseExample2());
    }
    [TestMethod]
    public void FromClauseExample3TestMethod()
    {
      Assert.AreEqual<string>("Name1:11000,00;Name3:130000,00", FromClause.FromClauseExample3());
    }

  }
}

