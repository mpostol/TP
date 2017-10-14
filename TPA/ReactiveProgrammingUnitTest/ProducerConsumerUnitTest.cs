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
            // Producer and consumer process setup
            _producerConsumer = new ProducerConsumer();
            _producerConsumer.Consumers.Add(new Consumer<int>());
            _producerConsumer.Consumers.Add(new Consumer<int>());
            _producerConsumer.Producers.Add(new Producer<int>(TimeSpan.FromSeconds(2)));
            _producerConsumer.Producers.Add(new Producer<int>(TimeSpan.FromSeconds(3)));
            _producerConsumer.Producers.Add(new Producer<int>(TimeSpan.FromSeconds(6)));
        }

        [TestMethod]
        public async Task CheckWhetherConsumersHaveSameResults()
        {
            Consumer<int> firstConsumer = _producerConsumer.Consumers[0];
            Consumer<int> secondConsumer = _producerConsumer.Consumers[1];
            // Start asynchronous producer and consumer process
            await _producerConsumer.StartAsync(TimeSpan.FromSeconds(10));
            IList<object> firstConsumerResults = firstConsumer.Results;
            IList<object> secondConsumerResults = secondConsumer.Results;
            // Check whether consumers have same results
            Assert.IsTrue(firstConsumerResults.SequenceEqual(secondConsumerResults));
        }

        private ProducerConsumer _producerConsumer;
    }
}
