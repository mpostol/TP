using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming.UnitTest
{
  [TestClass]
  public class KeyboardUnitTest
  {

    [TestMethod]
    public void TPAReadKeyFromKeyboardBufferAsyncTest()
    {
      using (Producer<TestingClass> _keyboard = new Producer<TestingClass>( new ProductFactory()))
      {
        List<TestingClass> _chars = new List<TestingClass>();
        long _counter = 0;
        for (int i = 0; i < 3; i++)
        {
          Task<TestingClass> _workToDo = _keyboard.TPAReadKeyFromKeyboardBufferAsync();
          while (_workToDo.Status != TaskStatus.RanToCompletion)
          {
            _counter++;
          };
          TestingClass _lastChar = _workToDo.Result;
          _chars.Add(_lastChar);
        }
        Assert.AreEqual<int>(3, _chars.Count);
        Assert.IsTrue(_counter > 1000000);
      }
    }

    [TestMethod]
    public void APMReadKeyFromKeyboardBuffer()
    {
      using (Producer<TestingClass> _keyboard = new Producer<TestingClass>(new ProductFactory()))
      {
        List<TestingClass> _chars = new List<TestingClass>();
        long _counter = 0;
        for (int i = 0; i < 3; i++)
        {
          bool _ended = false;
          IAsyncResult asyncResult = _keyboard.BeginReadKeyFromKeyboardBuffer(x => _ended = true, null);
          while (!_ended)
          {
            _counter++;
          };
          _chars.Add(_keyboard.EndReadKeyFromKeyboardBuffer(asyncResult));
        }
        Assert.AreEqual<int>(3, _chars.Count);
        Assert.IsTrue(_counter > 1000000);
      }
    }

    [TestMethod]
    public void EAPReadKeyFromKeyboardBufferAsyncTest()
    {
      using (Producer<TestingClass> _keyboard = new Producer<TestingClass>(new ProductFactory()))
      {
        List<TestingClass> _chars = new List<TestingClass>();
        bool _ended = false;
        long _counter = 0;
        _keyboard.ReadKeyFromKeyboardBufferCompleted += (sender, args) =>
            {
              _chars.Add(args.Result);
              _ended = true;
            };
        _keyboard.EAPReadKeyFromKeyboardBufferAsync();
        while (!_ended)
        {
          _counter++;
        };
        Assert.IsTrue(_counter > 200000, $"Counetr = {_counter}");
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
