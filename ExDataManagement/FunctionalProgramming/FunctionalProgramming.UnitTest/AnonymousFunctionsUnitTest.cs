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
using System.Linq;
using System.Linq.Expressions;

namespace TP.FunctionalProgramming
{
  [TestClass]
  public class AnonymousFunctionsUnitTest
  {
    /// <summary>
    /// While raising this delegate variable the null-conditional operator is not applied.
    /// Hence, this argument must not be null to prevent throwing an exception.
    /// </summary>
    [TestMethod]
    public void NullCallBack()
    {
      AnonymousFunctions _newInstance = new AnonymousFunctions();
      Assert.ThrowsException<NullReferenceException>(() => _newInstance.ConsistencyCheck(null));
    }

    [TestMethod]
    public void NamedMethodCallBackTest()
    {
      AnonymousFunctions _newInstance = new AnonymousFunctions();
      CallBackTestClass _callBackResult = new CallBackTestClass();
      Assert.IsFalse(_callBackResult.m_TestResult);
      AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = new AnonymousFunctions.CallBackTestDelegate(_callBackResult.CallBackTestResult);
      _newInstance.ConsistencyCheck(_CallBackTestResult);
      Assert.IsTrue(_callBackResult.m_TestResult);
    }

    [TestMethod]
    public void AnonymousMethodCallBackTest()
    {
      AnonymousFunctions _newInstance = new AnonymousFunctions();
      bool _testResult = false;
      AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = delegate (bool _result) { _testResult = _result; };
      //void _CallBackTestResult(bool _result) { _testResult = _result; }
      _newInstance.ConsistencyCheck(_CallBackTestResult);
      Assert.IsTrue(_testResult);
    }

    [TestMethod]
    public void LambdaExpressionCallBackTest()
    {
      AnonymousFunctions _newInstance = new AnonymousFunctions();
      bool _testResult = false;
      AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = _result => _testResult = _result;
      _newInstance.ConsistencyCheck(_CallBackTestResult);
      Assert.IsTrue(_testResult);
    }

    [TestMethod]
    public void LambdaSyntaxTest()
    {
      const int _length = 10000;
      Random _newRandom = new Random();
      int[] _buffer = new int[_length];
      for (int i = 0; i < _length; i++)
        _buffer[i] = _newRandom.Next(0, 100);
      int _count = _buffer.Count((int x) => { return x >= 50; });
      const int _tolerance = 130;
      Assert.IsTrue(_count > _length / 2 - _tolerance && _count < _length / 2 + _tolerance, $"{nameof(_count)}={_count}");
    }

    [TestMethod]
    public void DelegateVsExpressionTest()
    {
      //delegate
#pragma warning disable IDE0039 // Use local function
      Func<int, bool> _delegateVariable = num => { return num < 5; };
#pragma warning restore IDE0039 // Use local function
      Assert.IsTrue(_delegateVariable(4));
      Assert.IsFalse(_delegateVariable(5));
      //Expression
      Expression<Func<int, bool>> lambda = (int num) => num < 5;
      Assert.IsTrue(lambda.Compile()(4));
      Assert.IsFalse(lambda.Compile()(5));
    }

    [TestMethod]
    public void EventTestMethod()
    {
      AnonymousFunctions _newInstance = new AnonymousFunctions();
      State _currentState = _newInstance.CurrentStateHandler.CurrentState;
      _newInstance.OnStateChanged += (x, y) => _currentState = y;
      Assert.AreEqual<State>(State.Idle, _currentState);
      _newInstance.CurrentStateHandler.GoToActive();
      Assert.AreEqual<State>(State.Active, _currentState);
      _newInstance.CurrentStateHandler.GoToIdle();
      Assert.AreEqual<State>(State.Idle, _currentState);
      //_newInstance.OnStateChanged(_newInstance, _newInstance.CurrentStateHandler.CurrentState);  //Error CS0070  The event 'AnonymousFunctions.OnStateChanged' can only appear on the left hand side of += or -= (except when used from within the type 'AnonymousFunctions')
      //_newInstance.OnStateChanged = null;  //Error CS0070  The event 'AnonymousFunctions.OnStateChanged' can only appear on the left hand side of += or -= (except when used from within the type 'AnonymousFunctions')
    }

    #region Instrumentation

    private class CallBackTestClass
    {
      internal bool m_TestResult = false;

      internal void CallBackTestResult(bool returnResult)
      {
        m_TestResult = returnResult;
      }
    }

    #endregion Instrumentation
  }
}