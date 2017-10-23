using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.AsynchronousBehavior.ConcurrentProgramming;

namespace ConcurrentProgrammingUnitTest
{
  [TestClass]
  public class KeyboardUnitTest
  {

    [TestMethod]
    public void CheckWhetherKeyboardGeneratesKeystrokes()
    {
      using (Keyboard _keyboard = new Keyboard())
      {
        List<char> _chars = new List<char>();
        long _counter = 0;
        for (int i = 0; i < 3; i++)
        {
          Task<char> _workToDo = _keyboard.TPAReadKeyFromKeyboardBufferAsync();
          while (_workToDo.Status != TaskStatus.RanToCompletion)
          {
            _counter++;
          };
          char _lastChar = _workToDo.Result;
          _chars.Add(_lastChar);
        }
        Assert.AreEqual<int>(3, _chars.Count);
        Assert.IsTrue(_counter > 1000000);
      }
    }

    [TestMethod]
    public void CheckWhetherKeyboardGeneratesKeystrokesUsingAPM()
    {
      using (Keyboard _keyboard = new Keyboard())
      {
        List<char> _chars = new List<char>();
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
    public async Task CheckWhetherKeyboardGeneratesKeystrokesUsingEAP()
    {
      using (Keyboard _keyboard = new Keyboard())
      {
        List<char> _chars = new List<char>();
        SemaphoreSlim semaphore = new SemaphoreSlim(0);

        _keyboard.ReadKeyFromKeyboardBufferCompleted += (sender, args) =>
        {
          _chars.Add(args.Result);
          semaphore.Release();
        };

        for (int i = 0; i < 3; i++)
        {
          _keyboard.EAPReadKeyFromKeyboardBufferAsync();
          await semaphore.WaitAsync();
        }

        Assert.IsTrue(_chars.Count == 3);
      }

    }
  }
}
