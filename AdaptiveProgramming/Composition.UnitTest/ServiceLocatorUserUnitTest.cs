//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2026, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using CommonServiceLocator;
using TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation;

namespace TPA.Composition.UnitTest
{
  [TestClass]
  public class ServiceLocatorUserUnitTest
  {
    [TestMethod]
    public void EmptyContainerTest()
    {
      ServiceLocator.SetLocatorProvider(() => new Container(null));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.ThrowsException<ActivationException>(() => _newUser.DataProcessing());
    }

    [TestMethod]
    public void DefaultLogTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
//          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      _newUser.DataProcessing();
      Assert.AreEqual<int>(1, Logger.LoggerInstance.Count);
    }

    [TestMethod]
    public void WrongKeyTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
          // new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.ThrowsException<ActivationException>(() => _newUser.DataProcessing("Random Text"));
    }

    [TestMethod]
    //[ExpectedException(typeof(NullReferenceException))]
    public void NullReferenceExceptionTest()
    {
      object[] _services = new object[]
        {
          Logger.LoggerInstance,
          //new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.ThrowsException<NullReferenceException>(() => _newUser.DataProcessingNullReferenceException());
    }
  }
}