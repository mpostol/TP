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
        [TestMethod]
        public async Task CheckWheterProducesWell()
        {
            TimeSpan period = TimeSpan.FromMilliseconds(100);
            int counter = 1;
            List<int> expectedProducts = new List<int> { 1, 2, 3 };
            IObservable<bool> consumerMock = Observable
                .Interval(period)
                .Select(_ => true)
                .Take(3);
            Producer<int> producer = new Producer<int>(() => counter++, period, 2);
            consumerMock.Subscribe(producer);
            IList<int> products = await producer.Take(3).ToList();
            Assert.IsTrue(expectedProducts.SequenceEqual(products));
        }
    }
}
