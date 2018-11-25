
using System;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
          new Logger(),
          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.IsNotNull(_newUser);
      _newUser.DataProcessing();
    }
    [TestMethod]
    public void AdvancedLoggerLogTest()
    {
      object[] _services = new object[]
        {
          new Logger(),
          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.IsNotNull(_newUser);
      _newUser.DataProcessing(typeof(AdvancedLogger).FullName);
    }
    [TestMethod]
    [ExpectedException(typeof(ActivationException))]
    public void WrongKeyTest()
    {
      object[] _services = new object[]
        {
          new Logger(),
          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.IsNotNull(_newUser);
      _newUser.DataProcessing("Random Text");
    }
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void NullReferenceExceptionTest()
    {
      object[] _services = new object[]
        {
          new Logger(),
          new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.IsNotNull(_newUser);
      _newUser.DataProcessingNullReferenceException();
    }

  }
}
