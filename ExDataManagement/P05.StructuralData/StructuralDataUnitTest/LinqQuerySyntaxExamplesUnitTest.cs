//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.StructuralData.LINQQueryAndMethodsSyntax;

namespace TP.StructuralDataUnitTest
{

  [TestClass]
  public class LinqQuerySyntaxExamplesUnitTest
  {

    [TestMethod]
    public void QuerySyntaxForeachExampleTest()
    {
      Assert.AreEqual<string>("grape", LinqQuerySyntaxExamples.ForeachExample());
      Assert.AreEqual<string>("grape", LinqQuerySyntaxExamples.QuerySyntax());
    }
    [TestMethod]
    public void QuerySyntaxSideEffectTest()
    {
      Assert.AreEqual<string>(string.Empty, LinqQuerySyntaxExamples.QuerySyntaxSideEffect());
    }
    [TestMethod]
    public void AnonymousTypeTest()
    {
      Assert.AreEqual<string>("Name1:11000.00; Name3:130000.00", LinqQuerySyntaxExamples.AnonymousType());
    }

  }
}

