//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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