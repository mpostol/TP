//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP.FunctionalProgramming
{
  /// <summary>
  /// This testing class reveals features of delegate.
  /// </summary>
  [TestClass]
  public class DelegateExampleUnitTest
  {
    /// <summary>
    /// Typically the delegate value is instantiated using a new operator.
    /// It is possible to instantiate the delegate value by applying more concise syntax
    /// using only the method name or definition of the anonymous function.
    /// </summary>
    [TestMethod]
    public void Instantiation()
    {
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = new DelegateExample.PerformCalculation(PerformSumMethod);// Delegate value instantiation using new operator
      Assert.IsNotNull(_newInstance.PerformCalculationVar);
      Assert.AreEqual<int>(5, _newInstance.PerformCalculationVar(2, 2));
      _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = PerformSumMethod; // Auto instantiation using only method name.
                                                             // It looks like assignment of a method to delegate variable
      Assert.IsNotNull(_newInstance.PerformCalculationVar);
      Assert.AreEqual<int>(5, _newInstance.PerformCalculationVar(2, 2));
      _newInstance.PerformCalculationVar = (x, y) => x + y + 1;
      Assert.IsNotNull(_newInstance.PerformCalculationVar);
      Assert.AreEqual<int>(5, _newInstance.PerformCalculationVar(2, 2));
    }

    /// <summary>
    /// The delegate variable is of reference type - the null value can be assigned.
    /// It indicates that invocation of the delegate variable containing null throws an exception.
    /// Thanks to the null-conditional operator nothing is invoked if the delegate variable evaluates to null
    /// </summary>
    [TestMethod]
    public void NullInvocation()
    {
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = null;
      Assert.ThrowsException<NullReferenceException>(() => _newInstance.PerformCalculationVar(0, 0));
      _newInstance.PerformCalculationVar?.Invoke(0, 0); //thanks to the null-conditional operator nothing is invoked
    }

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
    public void MultiCastTestMethod()
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

    /// <summary>
    /// This function adds the values of two integers and returns the result incremented by 1.
    /// </summary>
    /// <param name="x">The first parameter used by the add operation</param>
    /// <param name="y">The second parameter used by the add operation</param>
    /// <returns>the sum of x and y parameters incremented by 1</returns>
    private int PerformSumMethod(int x, int y)
    {
      checked
      {
        return x + y + 1;
      }
    }
  }
}