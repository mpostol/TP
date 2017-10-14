using System;
using System.Reactive.Linq;

namespace TPA.AsynchronousBehavior.ReactiveProgramming
{
    public class TickEventArgs : EventArgs
    {
        // Lets notify current counter to subscribers
        public TickEventArgs(long counter)
        {
            Counter = counter;
        }

        public long Counter
        {
            get;
            private set;
        }
    }

    public delegate void TickEventHandler(object sender, TickEventArgs e);

    public class Timer
    {
        public Timer(TimeSpan period)
        {
            Period = period;
        }

        public void Start()
        {
            // Create observable when needed
            _timerObservable = Observable
                .Interval(Period);
            _timerObservable.Subscribe(c => RaiseTick(c));
        }

        private void RaiseTick(long counter)
        {
            // Make safe call
            Tick?.Invoke(this, new TickEventArgs(counter));
        }

        public event TickEventHandler Tick;

        public TimeSpan Period
        {
            get;
            private set;
        }

        private IObservable<long> _timerObservable;
    }
}