#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable IDE0049
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
      Int32 _integer = 5; 
      _integer = _integer / 2;
      Assert.AreEqual(2, _integer);
    }
    [TestMethod]
    public void ReferenceTypeCompatibilityTest()
    {
      CoordinatesClass _ = null;
      IndependentClass _reference1 = null;
      Segment _reference2 = null;
      Assert.AreSame(_reference1, _reference2);
      //_reference1 = _reference2;
      //_reference2 = _reference1;
    }
    private class IndependentClass { }
    #endregion

    #region Reference and value types
    [TestMethod]
    public void StructTestMethod()
    {
      //value type modification 
      CoordinatesStruct _coordinate1 = CoordinatesStruct.GetCoordinates(1, 2);
      CoordinatesStruct _coordinate2 = CoordinatesStruct.GetCoordinates(1, 2);
      CoordinatesNoChange(_coordinate1);
      Assert.AreEqual(_coordinate1, _coordinate2);
      Assert.AreEqual(_coordinate1.x, _coordinate2.x);
      Assert.AreEqual(_coordinate1.y, _coordinate2.y);
      CoordinatesChange(ref _coordinate1);
      Assert.AreNotEqual(_coordinate1, _coordinate2);
      Assert.AreNotEqual(_coordinate1.x, _coordinate2.x);
      Assert.AreNotEqual(_coordinate1.y, _coordinate2.y);

      //Reference type modification
      CoordinatesClass _coordinateReference1 = null;
      Assert.IsNull(_coordinateReference1);
      _coordinateReference1 = new CoordinatesClass(1, 2);
      CoordinatesClass _coordinateReference2 = new CoordinatesClass(1, 2);
      Assert.AreEqual(_coordinateReference1.x, _coordinateReference2.x);
      Assert.AreEqual(_coordinateReference1.y, _coordinateReference2.y);
      Assert.AreNotEqual(_coordinateReference1, _coordinateReference2);
      Assert.AreNotSame(_coordinateReference1, _coordinateReference2);
      CoordinatesChange(_coordinateReference1);
      Assert.AreNotEqual(_coordinateReference1.x, _coordinateReference2.x);
      Assert.AreNotEqual(_coordinateReference1.y, _coordinateReference2.y);
    }
    private static Random m_RandomGenerator = new Random(DateTime.Now.Millisecond);
    private static void CoordinatesNoChange(CoordinatesStruct coordinates)
    {
      coordinates.x = m_RandomGenerator.Next();
      coordinates.y = m_RandomGenerator.Next();
    }
    private static void CoordinatesChange(ref CoordinatesStruct coordinates)
    {
      coordinates.x = m_RandomGenerator.Next();
      coordinates.y = m_RandomGenerator.Next();
    }
    private static void CoordinatesChange(CoordinatesClass coordinates)
    {
      coordinates.x = m_RandomGenerator.Next();
      coordinates.y = m_RandomGenerator.Next();
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

    #region Static class versus singleton
    [TestMethod]
    public void StaticClassTest()
    {
      //StaticClass _staticVariable;
      StaticClass.StaticClassInitializer(3.0, 1.0);
      Assert.AreEqual(1.0, StaticClass.MinIncome);
      Assert.AreEqual(3.0, StaticClass.MaxIncome);
      Assert.AreEqual(2.0, StaticClass.AverageIncome);
    }
    [TestMethod]
    public void SingletonTest()
    {
      Singleton _instance1 = Singleton.SingletonInstance;
      Singleton _instance2 = Singleton.SingletonInstance;
      Assert.AreSame(_instance1, _instance2);
      Assert.AreEqual(_instance1.GetHashCode(), _instance1.GetHashCode());
    }
    #endregion

  }
}
#pragma warning restore CS0219 // Variable is assigned but its value is never used
#pragma warning restore IDE0049
