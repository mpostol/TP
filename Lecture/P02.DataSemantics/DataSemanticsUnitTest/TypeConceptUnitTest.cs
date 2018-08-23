//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP.DataSemantics.TypeConcept;

namespace TP.DataSemantics
{
  [TestClass]
  public class StructUnitTest
  {
    [TestMethod]
    public void StructTestMethod()
    {
      //value type modification 
      CoordinatesStruct _bts1 = CoordinatesStruct.GetCoOrdsStruct();
      CoordinatesStruct _bts2 = CoordinatesStruct.GetCoOrdsStruct();
      CoOrdsNoChange(_bts1);
      Assert.AreNotSame(_bts1, _bts2);
      Assert.AreEqual(_bts1, _bts2);
      Assert.IsTrue(_bts1.x == _bts2.x);
      Assert.IsTrue(_bts1.y == _bts2.y);
      //
      CoOrdsChange(ref _bts1);
      Assert.AreNotEqual(_bts1, _bts2);
      Assert.IsTrue(_bts1.x != _bts2.x);
      Assert.IsTrue(_bts1.y != _bts2.y);

      //Reference type modification
      CoordinatesClass _btscoc1 = new CoordinatesClass(1, 2);
      CoordinatesClass _btscoc2 = new CoordinatesClass(1, 2);
      CoOrdsChange(_btscoc1);
      Assert.AreNotSame(_btscoc1, _btscoc2);
      Assert.AreNotEqual(_btscoc1, _btscoc2);
      Assert.IsTrue(_btscoc1.x != _btscoc2.x);
      Assert.IsTrue(_btscoc1.y != _btscoc2.y);

    }
    private static Random _randomGeneratopr = new Random(DateTime.Now.Millisecond);
    private static void CoOrdsNoChange(CoordinatesStruct coOrds)
    {
      coOrds.x = _randomGeneratopr.Next();
      coOrds.y = _randomGeneratopr.Next();
    }
    private static void CoOrdsChange(ref CoordinatesStruct coOrds)
    {
      coOrds.x = _randomGeneratopr.Next();
      coOrds.y = _randomGeneratopr.Next();
    }
    private static void CoOrdsChange(CoordinatesClass coOrds)
    {
      coOrds.x = _randomGeneratopr.Next();
      coOrds.y = _randomGeneratopr.Next();
    }

  }
  [TestClass]
  public class InterfaceTestClass
  {
    private const int c_OkIndex = 1;
    private const int c_WrongIndex = 25;
    [TestMethod]
    public void InterfaceTestMethod()
    {
      InterfaceExample _ie = new InterfaceExample();
      double _val = _ie[c_OkIndex];
      _ie[1] = new Random().NextDouble();
      Assert.AreNotEqual(_val, _ie[c_OkIndex]);
    }
    [TestMethod]
    public void InteraceCountTestMethod()
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
  }

}

