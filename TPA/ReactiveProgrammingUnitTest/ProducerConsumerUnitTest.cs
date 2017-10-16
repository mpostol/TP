using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.AsynchronousBehavior.ReactiveProgramming;

namespace ReactiveProgrammingUnitTest
{
    [TestClass]
    public class ProducerConsumerUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _producer = new Producer<int>(() => ++_counter);
            _consumer = new Consumer<int>();
            _producerConsumer = new ProducerConsumer<int>(_producer, _consumer, 2);
        }

        [TestMethod]
        public async Task CheckWhetherProducerProducesWell()
        {
            List<int> expectedProducedItems = new List<int> { 1, 2, 3 };
            List<int> producedItems = new List<int>();
            IObservable<EventPattern<ProducedEventArgs<int>>> producedObservable = Observable
                .FromEventPattern<ProducedEventArgs<int>>(_producer, "Produced");
            IDisposable subscriber = producedObservable.Subscribe(e => producedItems.Add(e.EventArgs.Product));
            _producerConsumer.Start(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(6));
            await Task.Delay(TimeSpan.FromSeconds(10));
            _producerConsumer.Stop();
            subscriber.Dispose();
            Assert.IsTrue(expectedProducedItems.SequenceEqual(producedItems));
        }

        [TestMethod]
        public async Task CheckWhetherConsumerConsumesWell()
        {
            List<int> expectedConsumedItems = new List<int> { 1, 2, 3 };
            List<int> consumedItems = new List<int>();
            IObservable<EventPattern<ConsumedEventArgs<int>>> consumedObservable = Observable
                .FromEventPattern<ConsumedEventArgs<int>>(_consumer, "Consumed");
            IDisposable subscriber = consumedObservable.Subscribe(e => consumedItems.Add(e.EventArgs.Product));
            _producerConsumer.Start(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3));
            await Task.Delay(TimeSpan.FromSeconds(10));
            _producerConsumer.Stop();
            subscriber.Dispose();
            Assert.IsTrue(expectedConsumedItems.SequenceEqual(consumedItems));
        }

        private int _counter = 0;
        private Producer<int> _producer;
        private Consumer<int> _consumer;
        private ProducerConsumer<int> _producerConsumer;
    }
}
