
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming.UnitTest
{
  [TestClass]
  public class ReactiveTimerUnitTest
  {

    [TestMethod]
    public void CheckWhetherTickRaised()
    {
      using (ReactiveTimer _timer = new ReactiveTimer(TimeSpan.FromSeconds(1)))
      {
        // Create observable from tick event
        IObservable<EventPattern<TickEventArgs>> _tickObservable = Observable.FromEventPattern<TickEventArgs>(_timer, "Tick");
        // Get first five tick event raises and count them
        IObservable<long> _firstFiveTickObservable = _tickObservable
          .Select(e => e.EventArgs.Counter)
          .Take(5);
        long _accumulator = 0;
        bool _completed = false;
        bool _error = false;
        using (IDisposable _observer = _firstFiveTickObservable.Subscribe(x => _accumulator += x, _ => _error = true, () => _completed = true))
        {

          System.Threading.Thread.Sleep(2000);
          Assert.AreEqual<long>(0, _accumulator);
          Assert.IsFalse(_completed);
          Assert.IsFalse(_error);
          // Setup complete, lets start timer
          _timer.Start();
          //}
          Stopwatch _watchDog = Stopwatch.StartNew();
          while (true)
          {
            if (_completed)
              break;
            if (_watchDog.Elapsed > TimeSpan.FromSeconds(7))
              Assert.Fail();
          }
        }
        Assert.AreEqual<long>(10, _accumulator);
        Assert.IsTrue(_completed);
        Assert.IsFalse(_error);
      }
    }

  }
}
