#pragma warning disable IDE0033 // Use explicitly provided tuple name

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
    public void VARTest()
    {
      Random _rdm = new Random();
      double _dividend = 5;// * _rdm.Next();
      double _double = _dividend / 2;
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
      int _integer = 5;
      //var _integer = 5;
      //_integer = ""; //Error CS0029  Cannot implicitly convert type 'string' to 'int' 
      _integer = _integer / 2;
      Assert.AreEqual(2, _integer);
    }
    [TestMethod]
    public void AnonymousType()
    {
      var _anonymousVariable = new { Amount = 108, Message = "Hello" };
      Assert.AreEqual(108, _anonymousVariable.Amount);
      Assert.AreEqual("Hello", _anonymousVariable.Message);
      //_anonymousVariable = new { Amount = 108.0, Message = "Hello" }; //Error CS0029  Cannot implicitly convert type '<anonymous type: double Amount, string Message>' to '<anonymous type: int Amount, string Message>' 
      //_anonymousVariable = new { Message = "Hello", Amount = 108 }; //Error CS0029  Cannot implicitly convert type '<anonymous type: string Message, int Amount>' to '<anonymous type: int Amount, string Message>'
      //_anonymousVariable.Message = ""; //Error CS0200  Property or indexer '<anonymous type: int Amount, string Message>.Message' cannot be assigned to --it is read only
      _anonymousVariable = null;
      //var _newAnonymousVariable = null; //Error CS0815  Cannot assign<null > to an implicitly-typed variable
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
      var _anonymousArray = new[] {
                              new { name = "apple", diam = 4 },
                              new { name = "grape", diam = 1 },
                              //new { diam = 2, name = "plum"  } 
                             };
      Assert.AreEqual(new { name = "apple", diam = 4 }, _anonymousArray[0]);
      Assert.AreEqual(new { name = "grape", diam = 1 }, _anonymousArray[1]);
    }
    [TestMethod]
    public void NoNewBehaviorValues()
    {
      Tuple<int, string> _classTuple = new Tuple<int, string>(108, "Hello");
      Assert.AreEqual(108, _classTuple.Item1);
      Assert.AreEqual("Hello", _classTuple.Item2);
      //_classTuple.Item1 = 801;
      _classTuple = null;

      ValueTuple<int, string> _valueTupleVariable = (108, "Hello");
      ValueTuple<int, string> __ = ValueTuple.Create<int, string>(108, "Hello");
      Assert.AreEqual(108, _valueTupleVariable.Item1);
      Assert.AreEqual("Hello", _valueTupleVariable.Item2);
      _valueTupleVariable.Item1 = 801;
      _valueTupleVariable.Item2 = "";
      //_valueTupleVariable = (108.0, "Hello"); //Error CS0029  Cannot implicitly convert type 'double' to 'int' 
      //_valueTupleVariable = ("Hello", 108); //Error CS0029  Cannot implicitly convert type 'string' to 'int'; Error CS0029  Cannot implicitly convert type 'int' to 'string' 
      //_valueTupleVariable = null; //Error CS0037  Cannot convert null to '(int, string)' because it is a non - nullable value type
    }
    [TestMethod]
    public void NamedFieldsValueTuple()
    {
      //(int Amount, string Message) _ = (108, "Hello");
      (int Amount, string Message) _valueTupleVariable = (Amount: 108, Message: "Hello");
      Assert.AreEqual(108, _valueTupleVariable.Item1);
      Assert.AreEqual(108, _valueTupleVariable.Amount);
      Assert.AreEqual("Hello", _valueTupleVariable.Item2);
      Assert.AreEqual("Hello", _valueTupleVariable.Message);
      _valueTupleVariable.Amount = 801;
      _valueTupleVariable.Message = "";
    }
    [TestMethod]
    public void ValueTupleEqality()
    {
      (int Amount, string Message) _valueTupleVariable1 = (108, "Hello");
      (int Amount, string Message) _valueTupleVariable2 = (108, "Hello");
      Assert.IsTrue(_valueTupleVariable1 == _valueTupleVariable2); //Error CS8107  Feature 'tuple equality' is not available in C# 7.0. Please use language version 7.3 or greater.
      Assert.AreEqual(_valueTupleVariable1, _valueTupleVariable2);
      _valueTupleVariable1 = _valueTupleVariable2;
    }
    [TestMethod]
    public void ValueTupleMethodTest()
    {
      (int Amount, string Message) _valueTupleVariable = InstrumentationTupleClass.GetValueTupleValue();
      Assert.AreEqual(108, _valueTupleVariable.Item1);
      Assert.AreEqual("Hello", _valueTupleVariable.Item2);
      _valueTupleVariable.Amount = 801;
      _valueTupleVariable.Message = "";
    }
    [TestMethod]
    public void ValueTupleDeconstructionMethodTest()
    {
      (int Amount, string Message) = InstrumentationTupleClass.GetValueTupleValue();
      Assert.AreEqual(108, Amount);
      Assert.AreEqual("Hello", Message);
      Amount = 801;
      Message = "";
    }
    private static class InstrumentationTupleClass
    {
      internal static (int Amount, string Message) GetValueTupleValue()
      {
        return (108, "Hello");
      }
    }

  }
}
#pragma warning restore IDE0033 // Use explicitly provided tuple name
