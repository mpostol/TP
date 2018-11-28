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
      _newInstance.PerformCalculationVar = new DelegateExample.PerformCalculation(_newInstance.PerformSumMethod) + new DelegateExample.PerformCalculation(DelegateExample.PerformSubtractMethod);
      _newInstance.PerformCalculationVar = new DelegateExample.PerformCalculation(PerformSumMethod);
      _newInstance.PerformCalculationVar += new DelegateExample.PerformCalculation(DelegateExample.PerformSubtractMethod);
      Assert.AreEqual<int>(-1, _newInstance.PerformCalculationMethod(1, 2));
    }
    [TestMethod]
    public void PerformSumMethodCalledTest()
    {
      DelegateExample _newInstance = new DelegateExample();
      int _Called = 0;
      object _sender = null;
      EventArgs _args = null;
      _newInstance.PerformSumMethodCalled += (x, y) => { _Called++; _sender = x; _args = y; };
      //_newInstance.PerformSumMethodCalled = (x, y) => { _Called++; _sender = x; _args = y; }; // The event 'DelegateExample.PerformSumMethodCalled' can only appear on the left hand side of += or -= (except when used from within the type 'DelegateExample')
      //_newInstance.PerformSumMethodCalled(this, EventArgs.Empty); //The event 'DelegateExample.PerformSumMethodCalled' can only appear on the left hand side of += or -= (except when used from within the type 'DelegateExample')	
      Assert.AreEqual<int>(0, _Called);
      _newInstance.PerformSumMethod(1, 2);
      Assert.AreEqual<int>(1, _Called);
      Assert.AreSame(_newInstance, _sender);
      Assert.AreSame(_args, EventArgs.Empty);
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
