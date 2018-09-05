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

    #region CoordinatesStruct
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
      Assert.IsTrue(_coordinateReference1.x != _coordinateReference2.x);
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
    public void MyTestMethod()
    {
      StaticClass.StaticClassInitializer(3.0, 1.0);
      Assert.AreEqual(1.0, StaticClass.MinIncome);
      Assert.AreEqual(3.0, StaticClass.MaxIncome);
      Assert.AreEqual(2.0, StaticClass.AverageIncome);
    }
    #endregion

  }
}

