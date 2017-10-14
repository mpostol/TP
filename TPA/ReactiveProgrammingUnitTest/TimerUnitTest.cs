using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using TPA.AsynchronousBehavior.ReactiveProgramming;

namespace ReactiveProgrammingUnitTest
{
    [TestClass]
    public class TimerUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _timer = new Timer(TimeSpan.FromSeconds(2));
        }

        [TestMethod]
        public async Task CheckWhetherTickRaised()
        {
            // Create observable from tick event
            IObservable<EventPattern<TickEventArgs>> tickObservable = Observable
                .FromEventPattern<TickEventArgs>(_timer, "Tick");
            // Get first five tick event raises and count them
            IObservable<int> firstFiveTickObservable = tickObservable
                .Select(e => e.EventArgs.Counter)
                .Take(5)
                .Scan(0, (acc, _) => acc + 1);
            // Setup complete, lets start timer
            _timer.Start();
            // Await for event raises count
            int counter = await firstFiveTickObservable;
            Assert.AreEqual(5, counter);
        }

        private Timer _timer;
    }
}
