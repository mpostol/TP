//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation;

namespace TPA.Composition.UnitTest
{
  [TestClass]
  public class ServiceLocatorUserUnitTest
  {

    [TestMethod]
    [ExpectedException(typeof(ActivationException))]
    public void EmptyContainerTest()
    {
      ServiceLocator.SetLocatorProvider(() => new Container(null));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.IsNotNull(_newUser);
      _newUser.DataProcessing();
    }
    [TestMethod]
    public void DefaultLogTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
          new AdvancedLogger(),
          new NullReferenceException()
        };
      Logger.LoggerInstance.MemoryLog.Clear();
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      _newUser.DataProcessing();
      Assert.AreEqual<int>(1, Logger.LoggerInstance.MemoryLog.Count);
    }
    [TestMethod]
    public void AdvancedLoggerLogTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
          new AdvancedLogger(),
          new NullReferenceException()
        };
      Logger.LoggerInstance.MemoryLog.Clear();
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      _newUser.DataProcessing(typeof(AdvancedLogger).FullName);
      Assert.AreEqual<int>(0, Logger.LoggerInstance.MemoryLog.Count);
    }
    [TestMethod]
    [ExpectedException(typeof(ActivationException))]
    public void WrongKeyTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      _newUser.DataProcessing("Random Text");
    }
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void NullReferenceExceptionTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      _newUser.DataProcessingNullReferenceException();
    }

  }
}
