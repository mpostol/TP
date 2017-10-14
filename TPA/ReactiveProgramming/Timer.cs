
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
    public class Timer
    {
        public Timer(TimeSpan period)
        {
            Period = period;
        }

        #region API
        public event EventHandler<TickEventArgs> Tick;
        //What happens after recalling Start ??
        public void Start()
        {
            // Create observable when needed
            m_TimerObservable = Observable.Interval(Period);
            //_ret is never used
            IDisposable _ret = m_TimerObservable.Subscribe(c => RaiseTick(c));
        }
        public TimeSpan Period
        {
            get;
            private set;
        }
        #endregion

        #region private
        private IObservable<long> m_TimerObservable;
        private void RaiseTick(long counter)
        {
            // Make safe call
            Tick?.Invoke(this, new TickEventArgs(counter));
        }
        #endregion
    }
}