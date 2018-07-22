//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.DataSemantics
{
  [TestClass]
  public class AnonymousTypesUnitTest
  {

    [TestMethod]
    public void FromClauseExample1TestMethod()
    {
      AnonymousTypes _fc = new AnonymousTypes();
      Assert.AreEqual<string>("108-Hello", _fc.AnonymousTypesMyTestMethod1());
    }

    [TestMethod]
    public void FromClauseExample2TestMethod()
    {
      AnonymousTypes _fc = new AnonymousTypes();
      Assert.AreEqual<string>("300-Eello", _fc.AnonymousTypesMyTestMethod2());
    }

    [TestMethod]
    public void FromClauseExample3TestMethod()
    {
      AnonymousTypes _fc = new AnonymousTypes();
      Assert.AreEqual<string>("300-Hello", _fc.AnonymousTypesMyTestMethod3());
    }

    [TestMethod]
    public void FromClauseExample4TestMethod()
    {
      AnonymousTypes _fc = new AnonymousTypes();
      Assert.AreEqual<string>("apple-4, grape-1", _fc.AnonymousTypesMyTestMethod4());
    }
    [TestMethod]
    public void FromClauseExample5TestMethod()
    {
      AnonymousTypes _fc = new AnonymousTypes();
      Assert.AreEqual<string>("300,12-Eello", _fc.AnonymousTypesMyTestMethod5());
    }

  }
}
