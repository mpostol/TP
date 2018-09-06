#pragma warning disable CS0219 // Variable is assigned but its value is never used
//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP.DataSemantics.TypeConcept
{
  [TestClass]
  public class TypeConceptUnitTest
  {

    #region Type and type compatibility
    [TestMethod]
    public void WhyWeNeedTypesIntBehavior()
    {
      int _integer = 5;
      _integer = _integer / 2;
      Assert.AreEqual(2, _integer);
    }
    [TestMethod]
    public void ClassCompatibilityTest()
    {
      MyClass _mc1 = null;
      MyClass2 _mc2 = null;
      //_mc1 = _mc2; //Error CS0029  Cannot implicitly convert type 'TP.DataSemantics.AnonymousTypesUnitTest.MyClass2' to 'TP.DataSemantics.AnonymousTypesUnitTest.MyClass'
    }
    private class MyClass { }
    private class MyClass2 { }
    [TestMethod]
    public void WhyWeNeedTypesDoubleBehavior()
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
    }
    #endregion

    #region Reference and value types
    [TestMethod]
    public void StructTestMethod()
    {
      //value type modification 
      CoordinatesStruct _coordinate1 = CoordinatesStruct.GetCoordinates();
      CoordinatesStruct _coordinate2 = CoordinatesStruct.GetCoordinates();
      CoordinatesNoChange(_coordinate1);
      Assert.AreEqual(_coordinate1, _coordinate2);
      Assert.AreEqual(_coordinate1.x, _coordinate2.x);
      Assert.AreEqual(_coordinate1.y, _coordinate2.y);
      CoordinatesChange(ref _coordinate1);
      Assert.AreNotEqual(_coordinate1, _coordinate2);
      Assert.IsTrue(_coordinate1.x != _coordinate2.x);
      Assert.IsTrue(_coordinate1.y != _coordinate2.y);

      //Reference type modification
      CoordinatesClass _coordinateReference1 = new CoordinatesClass(1, 2);
      CoordinatesClass _coordinateReference2 = new CoordinatesClass(1, 2);
      CoordinatesChange(_coordinateReference1);
      Assert.AreNotSame(_coordinateReference1, _coordinateReference2);
      Assert.AreNotEqual(_coordinateReference1.x, _coordinateReference2.x);
      Assert.IsTrue(_coordinateReference1.y != _coordinateReference2.y);
    }
    private static Random _randomGenerator = new Random(DateTime.Now.Millisecond);
    private static void CoordinatesNoChange(CoordinatesStruct coordinates)
    {
      coordinates.x = _randomGenerator.Next();
      coordinates.y = _randomGenerator.Next();
    }
    private static void CoordinatesChange(ref CoordinatesStruct coordinates)
    {
      coordinates.x = _randomGenerator.Next();
      coordinates.y = _randomGenerator.Next();
    }
    private static void CoordinatesChange(CoordinatesClass coordinates)
    {
      coordinates.x = _randomGenerator.Next();
      coordinates.y = _randomGenerator.Next();
    }
    #endregion

    #region InterfaceExample
    [TestMethod]
    public void InterfaceTestMethod()
    {
      InterfaceExample _ie = new InterfaceExample();
      double _val = _ie[c_OkIndex];
      _ie[1] = new Random().NextDouble();
      Assert.AreNotEqual(_val, _ie[c_OkIndex]);
    }
    [TestMethod]
    public void InterfaceCountTestMethod()
    {
      InterfaceExample _ie = new InterfaceExample();
      int _length = 0;
      foreach (double _item in _ie)
        _length++;
      Assert.AreEqual(_length, _ie.Count);
    }
    [TestMethod]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(IndexOutOfRangeException))]
    public void InterfaceExceptionTestMethod()
    {
      InterfaceExample _ie = new InterfaceExample();
      double _val = _ie[c_WrongIndex];
    }
    private const int c_OkIndex = 1;
    private const int c_WrongIndex = 25;
    #endregion

    #region StaticClass
    [TestMethod]
    public void StaticClassTest()
    {
      StaticClass.StaticClassInitializer(3.0, 1.0);
      Assert.AreEqual(1.0, StaticClass.MinIncome);
      Assert.AreEqual(3.0, StaticClass.MaxIncome);
      Assert.AreEqual(2.0, StaticClass.AverageIncome);
    }
    #endregion

  }
}
#pragma warning restore CS0219 // Variable is assigned but its value is never used

