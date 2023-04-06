//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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