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

using AdaptiveProgramming.Composition.Plugins.PluginContract;
using AdaptiveProgramming.Composition.Plugins.PluginsImplementations.Lower;
using AdaptiveProgramming.Composition.Plugins.PluginsImplementations.Upper;
using AdaptiveProgramming.Composition.UnitTest.Instrumentation;
using CommonServiceLocator;
using TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation;
using TPA.Composition.UnitTest.Instrumentation;

namespace AdaptiveProgramming.Composition.UnitTest
{

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
          InMemoryLogger.LoggerInstance,
          ImplementationOfCustomLogger.LoggerInstance,
          new NullReferenceException(),
          LowercasePlugin.PluginInstance,
          UppercasePlugin.PluginInstance
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      IPluginContract _pluginContract = _newUser.DataProcessing<IPluginContract>();
      Assert.IsNotNull(_pluginContract);
      Assert.AreSame(LowercasePlugin.PluginInstance, _pluginContract);
      _pluginContract.PerformAction(new StringContext { Text = "Random Text" });
      Assert.AreEqual("random text", LowercasePlugin.PluginInstance.Name);
    }

    [TestMethod]
    public void MyTestMethod()
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
      IPluginContract _logger = _newUser.DataProcessing<IPluginContract>("AdaptiveProgramming.Composition.UnitTest.Instrumentation.ImplementationOfCustomLogger,UppercasePlugin");
      Assert.IsNotNull(_logger);
      Assert.AreSame(UppercasePlugin.PluginInstance, _logger);
      _logger.Log("Random Text");
      Assert.AreEqual("Random Text", ImplementationOfCustomLogger.LastLog);
    }

    [TestMethod]
    public void WrongKeyTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
           LowercasePlugin.PluginInstance(),
          UppercasePlugin.PluginInstance(),
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
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      Assert.ThrowsException<NullReferenceException>(() => _newUser.DataProcessingNullReferenceException());
    }
  }

  //[TestMethod]
  //public void LoadPluginsTest()
  //{
  //  //Load plugins from <ApplicationName>.config
  //  //VS automatically copy App.config to <ApplicationName>.config
  //  //Requires reference to System.Configuration
  //  List<IPlugin> _plugins = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
  //  Assert.IsNotNull(_plugins);
  //  Assert.AreEqual(2, _plugins.Count);
  //  Assert.AreEqual("Uppercase Plugin", _plugins[0].Name);
  //  Assert.AreEqual("Lowercase Plugin", _plugins[1].Name);
  //}

  //[TestMethod]
  //public void UppercasePluginTest()
  //{
  //  List<IPlugin> _plugins = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
  //  Assert.IsNotNull(_plugins);
  //  StringContext _stringContext = new StringContext("This is only Rock'n'roll");
  //  _plugins[0].PerformAction(_stringContext); //Perform operation on data
  //  Assert.AreEqual("THIS IS ONLY ROCK'N'ROLL", _stringContext.Text);
  //}

  //[TestMethod]
  //public void LowercasePluginTest()
  //{
  //  List<IPlugin> _plugins = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
  //  Assert.IsNotNull(_plugins);
  //  StringContext _stringContext = new StringContext("ART OF FLYING");
  //  _plugins[1].PerformAction(_stringContext); //Perform operation on data
  //  Assert.AreEqual("art of flying", _stringContext.Text);
  //}

  //Implementation of IPluginContext

  #region instrumentation


  internal class StringContext : IPluginContext
  {
    public string Text { get; set; }
  }

  #endregion instrumentation
}
