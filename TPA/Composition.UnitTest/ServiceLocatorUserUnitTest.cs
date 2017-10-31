
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
    public void ConstructorNotContainerTest()
    {
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
    }
    [TestMethod]
    [ExpectedException(typeof(ActivationException))]
    public void EmptyContainerTest()
    {
      ServiceLocator.SetLocatorProvider(() => new Container(null));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.IsNotNull(_newUser);
      _newUser.DataProcessingWithSimpleLog();
    }
    [TestMethod]
    public void SingletonContainerTest()
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
      _newUser.DataProcessingWithSimpleLog();
    }
  }
}
