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

using AdaptiveProgramming.Composition.Plugins.PluginsImplementations.Lower;
using AdaptiveProgramming.Composition.Plugins.PluginsImplementations.Upper;
using AdaptiveProgramming.Composition.UnitTest.Instrumentation;
using CommonServiceLocator;
using TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation;

namespace AdaptiveProgramming.Composition.UnitTest
{
  [TestClass]
  public class CustomLoggerTest
  {
    [TestMethod]
    public void DefaultLogTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          ImplementationOfCustomLogger.LoggerInstance,
          new NullReferenceException(),
          LowercasePlugin.PluginInstance,
          UppercasePlugin.PluginInstance
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      ICustomLogger _logger = _newUser.DataProcessing<ICustomLogger>();
      Assert.IsNotNull(_logger);
      Assert.AreSame(InMemoryLogger.LoggerInstance, _logger);
      _logger.Log("Rlr&LTxAx9F&2vOQ");
      Assert.AreEqual(1, InMemoryLogger.LoggerInstance.Count);
    }
    
    [TestMethod]
    public void ImplementationOfCustomLoggerTestMethod()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          ImplementationOfCustomLogger.LoggerInstance,
          new NullReferenceException(),
          LowercasePlugin.PluginInstance,
          UppercasePlugin.PluginInstance
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      ICustomLogger _plugin = _newUser.DataProcessing<ICustomLogger>("AdaptiveProgramming.Composition.UnitTest.Instrumentation.ImplementationOfCustomLogger");
      Assert.IsNotNull(_plugin);
      Assert.AreSame(ImplementationOfCustomLogger.LoggerInstance, _plugin);
      _plugin.Log("5*!2AVEx5wmE0Bzz");
      Assert.AreEqual("5*!2AVEx5wmE0Bzz", ImplementationOfCustomLogger.LastLog);
    }

    [TestMethod]
    public void WrongKeyTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          LowercasePlugin.PluginInstance,
          UppercasePlugin.PluginInstance,
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.ThrowsException<ActivationException>(() => _newUser.DataProcessing<ICustomLogger>("Random Text"));
    }

    [TestMethod]
    public void NullReferenceExceptionTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          //new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ();
      Assert.ThrowsException<NullReferenceException>(() => _newUser.DataProcessingNullReferenceException());
    }
  }
}