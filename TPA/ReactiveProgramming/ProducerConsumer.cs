using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using TPA.AsynchronousBehavior.ReactiveProgramming;

namespace ReactiveProgrammingUnitTest
{
    public enum BufferState
    {
        Empty,
        Mediate,
        Full
    }

    public class BufferInfo<TProduct>
    {
        public BufferInfo(BufferState state, TProduct topProduct)
        {
            State = state;
            TopProduct = topProduct;
        }

        public BufferState State
        {
            get;
            private set;
        }

        public TProduct TopProduct
        {
            get;
            private set;
        }
    }

    public class ProducedEventArgs<TProduct>
    {
        public ProducedEventArgs(TProduct product)
        {
            Product = product;
        }

        public TProduct Product
        {
            get;
            private set;
        }
    }

    public class ConsumedEventArgs<TProduct>
    {
        public ConsumedEventArgs(TProduct product)
        {
            Product = product;
        }

        public TProduct Product
        {
            get;
            private set;
        }
    }

    public delegate void ProducedEventHandler<TProduct>(object sender, ProducedEventArgs<TProduct> e);
    public delegate void ConsumedEventHandler<TProduct>(object sender, ConsumedEventArgs<TProduct> e);

    public class Producer<TProduct>
    {
        public Producer(Func<TProduct> produce)
        {
            Produce = produce;
        }

        public void Start(IObservable<BufferInfo<TProduct>> bufferInfoObservable, ISubject<TProduct> productSubject)
        {
            _subscriber = bufferInfoObservable
                .Where(s => s.State != BufferState.Full)
                .Subscribe(onNext: _ =>
                {
                    TProduct product = Produce();
                    productSubject.OnNext(product);
                    RaiseProduced(product);
                });
        }

        public void Stop()
        {
            _subscriber.Dispose();
        }

        private void RaiseProduced(TProduct product)
        {
            Produced?.Invoke(this, new ProducedEventArgs<TProduct>(product));
        }

        public event ProducedEventHandler<TProduct> Produced;

        public Func<TProduct> Produce
        {
            get;
            private set;
        }

        private IDisposable _subscriber;
    }

    public class Consumer<TProduct>
    {
        public void Start(IObservable<BufferInfo<TProduct>> bufferStateObservable)
        {
            _subscriber = bufferStateObservable
                .Where(s => s.State != BufferState.Empty)
                .Select(s => s.TopProduct)
                .Subscribe(p => RaiseConsumed(p));
        }

        public void Stop()
        {
            _subscriber.Dispose();
        }

        private void RaiseConsumed(TProduct product)
        {
            Consumed?.Invoke(this, new ConsumedEventArgs<TProduct>(product));
        }

        public event ConsumedEventHandler<TProduct> Consumed;

        private IDisposable _subscriber;
    }

    public class ProducerConsumer<TProduct>
    {
        public ProducerConsumer(Producer<TProduct> producer, Consumer<TProduct> consumer, int bufferCapacity)
        {
            Producer = producer;
            Consumer = consumer;
            BufferCapacity = bufferCapacity;
        }

        public void Start(TimeSpan producerEmissionPeriod, TimeSpan consumerEmissionPeriod)
        {
            ISubject<TProduct> productSubject = new Subject<TProduct>();
            IObservable<TProduct> producedObservable = productSubject;
            IObservable<BufferInfo<TProduct>> consumerStateObservable = Observable
                .Interval(consumerEmissionPeriod)
                .Select(_ => GenerateBufferInfo(true));
            IObservable<BufferInfo<TProduct>> producerStateObservable = Observable
                .Interval(producerEmissionPeriod)
                .Select(_ => GenerateBufferInfo());
            _subscriber = producedObservable.Subscribe(p => EnqueueToBuffer(p));
            Producer.Start(producerStateObservable, productSubject);
            Consumer.Start(consumerStateObservable);
        }

        public void Stop()
        {
            _subscriber.Dispose();
            Producer.Stop();
            Consumer.Stop();
        }

        private void EnqueueToBuffer(TProduct product)
        {
            lock (_bufferLockObject)
            {
                _buffer.Enqueue(product);
            }
        }

        private BufferInfo<TProduct> GenerateBufferInfo(bool dequeueAfter = false)
        {
            lock (_bufferLockObject)
            {
                int bufferSize = _buffer.Count;
                BufferState bufferState;
                TProduct bufferTopProduct;

                if (bufferSize == 0)
                {
                    bufferTopProduct = default(TProduct);
                    bufferState = BufferState.Empty;
                }
                else
                {
                    bufferTopProduct = _buffer.Peek();
                    bufferState = bufferSize == BufferCapacity ? BufferState.Full : BufferState.Mediate;
                }

                BufferInfo<TProduct> bufferInfo = new BufferInfo<TProduct>(bufferState, bufferTopProduct);

                if (dequeueAfter && bufferSize >= 1)
                {
                    _buffer.Dequeue();
                }

                return bufferInfo;
            }
        }

        public Producer<TProduct> Producer
        {
            get;
            private set;
        }

        public Consumer<TProduct> Consumer
        {
            get;
            private set;
        }

        public int BufferCapacity
        {
            get;
            private set;
        }

        private Queue<TProduct> _buffer = new Queue<TProduct>();
        private object _bufferLockObject = new object();
        private IDisposable _subscriber;
    }
}
