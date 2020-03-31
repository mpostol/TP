//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPD.AsynchronousProgramming
{
  [TestClass]
  public class CriticalSectionExampleUnitTest
  {
    [TestMethod]
    public void StartThreadsMonitoredTest()
    {
      CriticalSectionExample _newSection = new CriticalSectionExample();
      _newSection.StartThreads(true);
      _newSection.GetConsistent(x => Assert.IsTrue(x));
      _newSection = new CriticalSectionExample();
      _newSection.StartThreads(false);
      _newSection.GetConsistent(x => Assert.IsFalse(x));
    }

    [TestMethod]
    public void StartThreadsUsingThreadPoolMonitoredTest()
    {
      CriticalSectionExample _newSection = new CriticalSectionExample();
      _newSection.StartThreadsUsingThreadPool(true);
      _newSection.GetConsistent(x => Assert.IsTrue(x));
      _newSection = new CriticalSectionExample();
      _newSection.StartThreadsUsingThreadPool(false);
      _newSection.GetConsistent(x => Assert.IsFalse(x));
    }

    [TestMethod]
    public void StartThreadsUsingTaskMonitoredTest()
    {
      CriticalSectionExample _newSection = new CriticalSectionExample();
      _newSection.StartThreadsUsingTask(true);
      _newSection.GetConsistent(x => Assert.IsTrue(x));
      _newSection = new CriticalSectionExample();
      _newSection.StartThreadsUsingTask(false);
      _newSection.GetConsistent(x => Assert.IsFalse(x));
    }
  }
}