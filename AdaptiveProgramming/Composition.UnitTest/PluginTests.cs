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
using AdaptiveProgramming.Composition.Plugins;
using AdaptiveProgramming.Composition.UnitTest.Instrumentation;
using CommonServiceLocator;

namespace AdaptiveProgramming.Composition.UnitTest
{

  [TestClass]
  public class PluginTests
  {
    [TestMethod]
    public void EmptyContainerTest()
    {
      ServiceLocator.SetLocatorProvider(() => new Container(null));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.ThrowsException<ActivationException>(() => _newUser.DataProcessing<IPluginContract>());
    }

    [TestMethod]
    public void DefaultLogTest()
    {
      object[] _services =
        {
          LowercasePlugin.PluginInstance,
          InMemoryLogger.LoggerInstance,
          ImplementationOfCustomLogger.LoggerInstance,
          new NullReferenceException(),
          UppercasePlugin.PluginInstance
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      IPluginContract _pluginContract = _newUser.DataProcessing<IPluginContract>();
      Assert.IsNotNull(_pluginContract);
      Assert.AreSame("Lowercase Plugin", LowercasePlugin.PluginInstance.Name);
      StringContext _context = new StringContext { Text = "Random Text" };
      _pluginContract.PerformAction(_context);
      Assert.AreEqual("random text", _context.Text);
    }

    [TestMethod]
    public void UppercasePluginTestMethod()
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
      IPluginContract _contract = _newUser.DataProcessing<IPluginContract>("AdaptiveProgramming.Composition.Plugins.UppercasePlugin");
      Assert.IsNotNull(_contract);
      Assert.AreSame(UppercasePlugin.PluginInstance, _contract);
      Assert.AreEqual(UppercasePlugin.PluginInstance.Name, "Uppercase Plugin");
      StringContext _context = new StringContext { Text = "Random Text" };
      _contract.PerformAction(_context);
      Assert.AreEqual("RANDOM TEXT", _context.Text);
    }

    [TestMethod]
    public void WrongKeyTest()
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
      Assert.ThrowsException<ActivationException>(() => _newUser.DataProcessing<ICustomLogger>("Random Text"));
    }

    [TestMethod]
    public void NullReferenceExceptionTest()
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
      Assert.ThrowsException<NullReferenceException>(() => _newUser.DataProcessingNullReferenceException());
    }
  }

  #region instrumentation

  internal class StringContext : IPluginContext
  {
    public string Text { get; set; } = "YY0JQILsyM7!a7F7";
  }

  #endregion instrumentation

}
