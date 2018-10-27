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
  public class LinqMethodSyntaxExamplesUnitTest
  {

    [TestMethod]
    public void LinqExtensionsExample1TestMethod()
    {
      Assert.AreEqual<string>("grape", LinqMethodSyntaxExamples.MethodSyntax());
    }
    [TestMethod]
    public void LinqExtensionsExample2TestMethod()
    {
      Assert.AreNotEqual<string>("grape", LinqMethodSyntaxExamples.DeferedExecution());
    }
    [TestMethod]
    public void LinqExtensionsExample3TestMethod()
    {
      Assert.AreEqual<string>("Name1:11000,00; Name3:130000,00", LinqMethodSyntaxExamples.AnonymousType());
    }

  }
}

