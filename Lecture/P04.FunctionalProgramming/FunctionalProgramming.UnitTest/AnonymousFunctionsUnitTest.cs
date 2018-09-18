//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace TP.FunctionalProgramming
{
  [TestClass]
  public class AnonymousFunctionsUnitTest
  {

    [TestMethod]
    public void NamedMethodCallBackTest()
    {
      AnonymousFunctions _newLambda = new AnonymousFunctions();
      CallBackTestClass _callBackResult = new CallBackTestClass();
      Assert.IsFalse(_callBackResult.m_TestResult);
      _newLambda.ConsistencyCheck(new AnonymousFunctions.CallBackTestDelegate(_callBackResult.CallBackTestResult));
      Assert.IsTrue(_callBackResult.m_TestResult);
    }
    [TestMethod]
    public void LambdaCallTest()
    {
      AnonymousFunctions _newLambda = new AnonymousFunctions();
      bool _testResult = false;
      _newLambda.ConsistencyCheck((bool _result) => _testResult = _result);
      Assert.IsTrue(_testResult);
    }
    [TestMethod]
    public void AnonymousMethodTest()
    {

      AnonymousFunctions _newLambda = new AnonymousFunctions();
      bool _testResult = false;
      AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = delegate (bool _result) { _testResult = _result; };
      _newLambda.ConsistencyCheck(_CallBackTestResult);
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
      Assert.IsTrue(_count > _length / 2 - 70 && _count < _length / 2 + 70, $"{nameof(_count)}={_count}");
    }
    [TestMethod]
    public void DelegateVsExpressionTest()
    {
      //delegate
      Func<int, bool> _delegateVariable = num => { return num < 5; };
      Assert.IsTrue(_delegateVariable(4));
      Assert.IsFalse(_delegateVariable(5));
      //Expression
      Expression<Func<int, bool>>  lambda = (int num) => num < 5;
      Assert.IsTrue(lambda.Compile()(4));
      Assert.IsFalse(lambda.Compile()(5));
    }
    private class CallBackTestClass
    {
      internal bool m_TestResult = false;
      internal void CallBackTestResult(bool returnResult)
      {
        m_TestResult = returnResult;
      }
    }

  }
}
