//____________________________________________________________________________
//
//  Copyright (C) 2019, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming.UnitTest
{
  [TestClass]
  public class ProducerUnitTest
  {

    [TestMethod]
    public void TPAReadKeyFromKeyboardBufferAsyncTest()
    {
      using (Producer<TestingClass> _producer = new Producer<TestingClass>(new ProductFactory()))
      {
        List<TestingClass> _products = new List<TestingClass>();
        long _counter = 0;
        for (int i = 0; i < 3; i++)
        {
          Task<TestingClass> _workToDo = _producer.TPAReadKeyFromKeyboardBufferAsync();
          while (_workToDo.Status != TaskStatus.RanToCompletion)
            _counter++;
          TestingClass _lastChar = _workToDo.Result;
          _products.Add(_lastChar);
        }
        Assert.AreEqual<int>(3, _products.Count);
        Assert.IsTrue(_counter > 1000000);
      }
    }
    [TestMethod]
    public void APMReadKeyFromKeyboardBuffer()
    {
      using (Producer<TestingClass> _producer = new Producer<TestingClass>(new ProductFactory()))
      {
        List<TestingClass> _products = new List<TestingClass>();
        long _counter = 0;
        for (int i = 0; i < 3; i++)
        {
          bool _ended = false;
          IAsyncResult asyncResult = _producer.BeginReadKeyFromKeyboardBuffer(x => _ended = true, null);
          while (!_ended)
            _counter++;
          _products.Add(_producer.EndReadKeyFromKeyboardBuffer(asyncResult));
        }
        Assert.AreEqual<int>(3, _products.Count);
        Assert.IsTrue(_counter > 1000000);
      }
    }
    [TestMethod]
    public void EAPReadKeyFromKeyboardBufferAsyncTest()
    {
      using (Producer<TestingClass> _producer = new Producer<TestingClass>(new ProductFactory()))
      {
        List<TestingClass> _products = new List<TestingClass>();
        bool _ended = false;
        long _counter = 0;
        _producer.ReadKeyFromKeyboardBufferCompleted += (sender, args) =>
            {
              _products.Add(args.Result);
              _ended = true;
            };
        _producer.EAPReadKeyFromKeyboardBufferAsync();
        while (!_ended)
          _counter++;
        Assert.IsTrue(_counter > 50000, $"Counter = {_counter}");
      }
    }
    private class ProductFactory : IProductFactory<TestingClass>
    {
      public TestingClass Create()
      {
        return new TestingClass();
      }
    }
    private class TestingClass { }
  }
}
