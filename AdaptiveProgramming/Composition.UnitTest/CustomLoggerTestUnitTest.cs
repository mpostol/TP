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

using AdaptiveProgramming.Composition.Contracts;
using AdaptiveProgramming.Composition.PluginsImplementations;
using AdaptiveProgramming.Composition.UnitTest.Implementation;
using AdaptiveProgramming.Composition.UnitTest.Instrumentation;
using CommonServiceLocator;

namespace AdaptiveProgramming.Composition.UnitTest
{
  [TestClass]
  public class CustomLoggerTests
  {
    [TestMethod]
    public void DefaultLogTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          InStringCustomLogger.LoggerInstance,
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
      int _count = -1;
      InMemoryLogger.LoggerInstance.Count(x => _count = x );
      Assert.AreEqual(1, _count);
    }
    
    [TestMethod]
    public void InStringCustomLoggerTestMethod()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          InStringCustomLogger.LoggerInstance,
          new NullReferenceException(),
          LowercasePlugin.PluginInstance,
          UppercasePlugin.PluginInstance
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      ICustomLogger _plugin = _newUser.DataProcessing<ICustomLogger>("AdaptiveProgramming.Composition.UnitTest.Instrumentation.InStringCustomLogger");
      Assert.IsNotNull(_plugin);
      Assert.AreSame(InStringCustomLogger.LoggerInstance, _plugin);
      _plugin.Log("5*!2AVEx5wmE0Bzz");
      Assert.AreEqual("5*!2AVEx5wmE0Bzz", InStringCustomLogger.LastLog);
    }

    [TestMethod]
    public void WrongKeyTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          InStringCustomLogger.LoggerInstance, 
          new NullReferenceException(),
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
          InStringCustomLogger.LoggerInstance, LowercasePlugin.PluginInstance,  
          //new AdvancedLogger(),
          new NullReferenceException()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ();
      Assert.ThrowsException<NullReferenceException>(() => _newUser.DataProcessingNullReferenceException());
    }
  }
}