//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP.DataSemantics
{
  [TestClass]
  public class AnonymousTypesUnitTest
  {

    [TestMethod]
    public void WhyWeNeedTypesIntBehaviour()
    {
      int _integer = 5;
      _integer = _integer / 2;
      Assert.AreEqual(2, _integer);
    }
    [TestMethod]
    public void ClassCompatibilityTest()
    {
      //MyClass _mc1 = null;
      //MyClass2 _mc2 = null;
      //_mc1 = _mc2; //Error CS0029  Cannot implicitly convert type 'TP.DataSemantics.AnonymousTypesUnitTest.MyClass2' to 'TP.DataSemantics.AnonymousTypesUnitTest.MyClass'
    }
    private class MyClass { }
    private class MyClass2 { }
    [TestMethod]
    public void WhyWeNeedTypesDopubleBehaviour()
    {
      Random _rdm = new Random();
      double _divident = 5;// * _rdm.Next();
      double _double = _divident / 2;
      Assert.AreEqual(2.5, _double);
      object _object = 5;
      //_object += 1; //Error CS0019  Operator '+=' cannot be applied to operands of type 'object' and 'int'
      Assert.IsTrue(_object is int);
      dynamic _dynamic = 0;
      _dynamic += 1.0;
      Assert.AreEqual(1, _dynamic);
      _dynamic = "String";
      Assert.AreEqual("String", _dynamic);
      _dynamic += 1.5;
      Assert.AreEqual("String1,5", _dynamic);
      Assert.AreEqual("1,5", 1.5.ToString());
      Assert.ThrowsException<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(() => _dynamic /= 1);
    }
    [TestMethod]
    public void VARTest()
    {
      var _integer = 5;
      //_integer = ""; //Error CS0029  Cannot implicitly convert type 'string' to 'int' 
      _integer = _integer / 2;
      Assert.AreEqual(2, _integer);
    }
    [TestMethod]
    public void AnonymousTypeTest()
    {
      var _anonymousVariable1 = new { Amount = 108, Message = "Hello" };
      Assert.AreEqual(108, _anonymousVariable1.Amount);
      Assert.AreEqual("Hello", _anonymousVariable1.Message);
      //_anonymousVariable1 = new { Amount = 108.0, Message = "Hello" }; //Error CS0029  Cannot implicitly convert type '<anonymous type: double Amount, string Message>' to '<anonymous type: int Amount, string Message>' 
      //_anonymousVariable1 = new { Message = "Hello", Amount = 108 }; //Error CS0029  Cannot implicitly convert type '<anonymous type: string Message, int Amount>' to '<anonymous type: int Amount, string Message>'
      //_anonymousVariable1.Message = ""; //Error CS0200  Property or indexer '<anonymous type: int Amount, string Message>.Message' cannot be assigned to --it is read only
      _anonymousVariable1 = null;
      //var _anonymousVariable = null; //Error CS0815  Cannot assign<null > to an implicitly-typed variable
    }
    [TestMethod]
    public void AnonymousTypesCompatibilityTest()
    {
      var _anonymousVariable1 = new { Amount = 108, Message = "Hello" };
      var _anonymousVariable2 = new { Amount = 108, Message = "Hello" };
      Assert.AreEqual(_anonymousVariable1, _anonymousVariable2);
      Assert.AreNotSame(_anonymousVariable1, _anonymousVariable2);
      _anonymousVariable1 = _anonymousVariable2;
      Assert.AreSame(_anonymousVariable1, _anonymousVariable2);
    }
    [TestMethod]
    public void AnonymousArrayTest()
    {
      var anonArray = new[] {
                              new { name = "apple", diam = 4 },
                              new { name = "grape", diam = 1 },
                              //new { diam = 2, name = "plum"  } 
                             };
      Assert.AreEqual(new { name = "apple", diam = 4 }, anonArray[0]);
      Assert.AreEqual(new { name = "grape", diam = 1 }, anonArray[1]);
    }

  }
}
