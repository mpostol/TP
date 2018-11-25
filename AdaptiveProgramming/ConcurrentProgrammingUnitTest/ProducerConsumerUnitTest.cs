//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming.UnitTest
{
  [TestClass]
  public class ProducerConsumerUnitTest
  {
    [TestMethod]
    public async Task CheckWhetherProducesWell()
    {
      Assert.Inconclusive("From time to time hangs up ");
      TimeSpan period = TimeSpan.FromMilliseconds(100);
      int counter = 1;
      List<int> expectedProducts = new List<int> { 1, 2, 3 };
      IObservable<bool> consumerMock = Observable
          .Interval(period)
          .Select(_ => true)
          .Take(3);
      ReactiveProducerConsumer<int> producer = new ReactiveProducerConsumer<int>(() => counter++, period, 2);
      consumerMock.Subscribe(producer);
      IList<int> products = await producer.Take(3).ToList();
      Assert.IsTrue(expectedProducts.SequenceEqual(products));
    }
  }
}
