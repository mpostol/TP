
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using TPA.AsynchronousBehavior.ReactiveProgramming;

namespace ReactiveProgrammingUnitTest
{
    public class ProducedEventArgs<objectType> : EventArgs
    {
        public ProducedEventArgs(objectType producedItem)
        {
            ProducedItem = producedItem;
        }
        public objectType ProducedItem
        {
            get;
            private set;
        }
    }
    public class ConsumedEventArgs<objectType> : EventArgs
    {
        public ConsumedEventArgs(objectType consumedItem)
        {
            ConsumedItem = consumedItem;
        }
        public objectType ConsumedItem
        {
            get;
            private set;
        }
    }
    public class Producer<ProductType>
    {
        // We want to produce item each period of time
        public Producer(TimeSpan period)
        {
            Period = period;
        }
        // Lets produce items into reactive subject
        public void Start(Subject<ProductType> subject, Func<ProductType> createProduct)
        {
            _subject = subject;
            _timer = new Timer(Period);
            IObservable<EventPattern<TickEventArgs>> timerTickObservable = Observable.FromEventPattern<TickEventArgs>(_timer, "Tick");
            // Each time timer ticks, we emit new object
            _subscriber = timerTickObservable.Subscribe(onNext: _ =>
            {
                ProductType obj = createProduct();
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
        private void RaiseProduced(ProductType obj)
        {
            Produced?.Invoke(this, new ProducedEventArgs<ProductType>(obj));
        }
        public event EventHandler<ProducedEventArgs<ProductType>> Produced;
        public TimeSpan Period
        {
            get;
            private set;
        }

        #region private
        private Timer _timer;
        private Subject<ProductType> _subject;
        private IDisposable _subscriber;
        #endregion
    }
    public class Consumer<ProductType>
    {
        // We want to consume items from observable
        public void Start(IObservable<ProductType> observable)
        {
            _subscriber = observable.Subscribe(onNext: o => RaiseConsumed(o));
        }
        public void Stop()
        {
            // We have to dispose subscriber in order to stop consuming process
            _subscriber.Dispose();
        }
        // Safe call
        public event EventHandler<ConsumedEventArgs<ProductType>> Consumed;
        public List<object> Results
        {
            get;
        } = new List<object>();
        private IDisposable _subscriber;
        private void RaiseConsumed(ProductType obj)
        {
            Results.Add(obj);
            Consumed?.Invoke(this, new ConsumedEventArgs<ProductType>(obj));
        }
    }
    public class ProducerConsumer
    {
        // Lets start producer and consumer process asynchronously for provided duration
        public async Task StartAsync(TimeSpan duration)
        {
            foreach (Consumer<int> consumer in Consumers)
                consumer.Start(_subject);
            foreach (Producer<int> producer in Producers)
                producer.Start(_subject, () => 1);
            // Consumers and producers setup complete, lets wait for some time
            await Task.Delay(duration);
            foreach (Producer<int> producer in Producers)
                producer.Stop();
            // We want to notify observers that all data have been emitted 
            _subject.OnCompleted();
            foreach (Consumer<int> consumer in Consumers)
                consumer.Stop();
        }
        public IObservable<int> Observable
        {
            get
            {
                return _subject;
            }
        }
        public List<Producer<int>> Producers
        {
            get;
        } = new List<Producer<int>>();

        public List<Consumer<int>> Consumers
        {
            get;
        } = new List<Consumer<int>>();
        private Subject<int> _subject = new Subject<int>();
    }
}
