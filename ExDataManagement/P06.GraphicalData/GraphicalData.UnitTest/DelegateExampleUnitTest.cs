//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP.GraphicalData
{
  [TestClass]
  public class DelegateExampleUnitTest
  {
    [TestMethod]
    public void SumTestMethod()
    {
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = _newInstance.PerformSumMethod;
      Assert.AreEqual<int>(_newInstance.PerformSumMethod(0, int.MaxValue), _newInstance.PerformCalculationVar(0, int.MaxValue));
      Assert.AreEqual<int>(_newInstance.PerformSumMethod(int.MinValue, int.MaxValue), _newInstance.PerformCalculationVar(int.MinValue, int.MaxValue));
    }
    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    public void OverflowTestMethod()
    {
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = _newInstance.PerformSumMethod;
      int _result = _newInstance.PerformCalculationVar(int.MaxValue, int.MaxValue);
    }
    [TestMethod]
    public void MulticastTestMethod()
    {
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = _newInstance.PerformSumMethod;
      //Multicast #1
      _newInstance.PerformCalculationVar = new DelegateExample.PerformCalculation(_newInstance.PerformSumMethod) + new DelegateExample.PerformCalculation(DelegateExample.PerformSubtractMethod);
      //Multicast #1
      _newInstance.PerformCalculationVar = new DelegateExample.PerformCalculation(PerformSumMethod);
      _newInstance.PerformCalculationVar += new DelegateExample.PerformCalculation(DelegateExample.PerformSubtractMethod);
      Assert.AreEqual<int>(-1, _newInstance.PerformCalculationMethod(1, 2));
    }
    private int PerformSumMethod(int x, int y)
    {
      checked
      {
        return x + y + 1;
      }
    }

  }
}
