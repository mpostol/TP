using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using TPA.AsynchronousBehavior.ReactiveProgramming;

namespace ReactiveProgrammingUnitTest
{
    public class ProducedEventArgs : EventArgs
    {
        public ProducedEventArgs(object producedItem)
        {
            ProducedItem = producedItem;
        }

        public object ProducedItem
        {
            get;
            private set;
        }
    }

    public class ConsumedEventArgs : EventArgs
    {
        public ConsumedEventArgs(object consumedItem)
        {
            ConsumedItem = consumedItem;
        }

        public object ConsumedItem
        {
            get;
            private set;
        }
    }

    public delegate void ProducedEventHandler(object sender, ProducedEventArgs e);
    public delegate void ConsumedEventHandler(object sender, ConsumedEventArgs e);

    public class Producer
    {
        // We want to produce item each period of time
        public Producer(TimeSpan period)
        {
            Period = period;
        }

        // Lets produce items into reactive subject
        public void Start(Subject<object> subject)
        {
            _subject = subject;
            _timer = new Timer(Period);
            IObservable<EventPattern<TickEventArgs>> timerTickObservable = Observable
                .FromEventPattern<TickEventArgs>(_timer, "Tick");
            // Each time timer ticks, we emit new object
            _subscriber = timerTickObservable.Subscribe(onNext: _ => {
                object obj = new object();
                _subject.OnNext(obj);
                RaiseProduced(obj);
            });
            // Setup complete, lets start timer
            _timer.Start();
        }

        public void Stop()
        {
            // We have to dispose subscriber in order to stop producing process
            _subscriber.Dispose();
        }

        // Safe call
        private void RaiseProduced(object obj)
        {
            Produced?.Invoke(this, new ProducedEventArgs(obj));
        }

        public event ProducedEventHandler Produced;

        public TimeSpan Period
        {
            get;
            private set;
        }

        private Timer _timer;
        private Subject<object> _subject;
        private IDisposable _subscriber;
    }

    public class Consumer
    {
        // We want to consume items from observable
        public void Start(IObservable<object> observable)
        {
            _subscriber = observable.Subscribe(onNext: o => RaiseConsumed(o));
        }

        public void Stop()
        {
            // We have to dispose subscriber in order to stop consuming process
            _subscriber.Dispose();
        }

        // Safe call
        private void RaiseConsumed(object obj)
        {
            Results.Add(obj);
            Consumed?.Invoke(this, new ConsumedEventArgs(obj));
        }

        public event ConsumedEventHandler Consumed;

        public List<object> Results
        {
            get;
        } = new List<object>();

        private IDisposable _subscriber;
    }

    public class ProducerConsumer
    {
        // Lets start producer and consumer process asynchronously for provided duration
        public async Task StartAsync(TimeSpan duration)
        {
            foreach (Consumer consumer in Consumers)
            {
                consumer.Start(_subject);
            }

            foreach (Producer producer in Producers)
            {
                producer.Start(_subject);
            }

            // Consumers and producers setup complete, lets wait for some time
            await Task.Delay(duration);

            foreach (Producer producer in Producers)
            {
                producer.Stop();
            }

            // We want to notify observers that all data have been emitted 
            _subject.OnCompleted();

            foreach (Consumer consumer in Consumers)
            {
                consumer.Stop();
            }
        }

        public IObservable<object> Observable
        {
            get
            {
                return _subject;
            }
        }

        public List<Producer> Producers
        {
            get;
        } = new List<Producer>();

        public List<Consumer> Consumers
        {
            get;
        } = new List<Consumer>();

        private Subject<object> _subject = new Subject<object>();
    }
}
