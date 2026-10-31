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
using AdaptiveProgramming.Composition.UnitTest.Instrumentation;
using CommonServiceLocator;
using TPA.Composition.Plugins.PluginsImplementations.Upper;
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
      Assert.ThrowsException<ActivationException>(() => _newUser.DataProcessing<ICustomLogger>());
    }

    [TestMethod]
    public void DefaultLogTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          ImplementationOfCustomLogger.LoggerInstance,
          new NullReferenceException(),
          new LowercasePlugin(),
          new UppercasePlugin()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      ICustomLogger _logger = _newUser.DataProcessing<ICustomLogger>();
      Assert.IsNotNull(_logger);
      Assert.AreSame(InMemoryLogger.LoggerInstance, _logger);
      _logger.Log("Random Text");
      Assert.AreEqual(1, InMemoryLogger.LoggerInstance.Count);
    }

    [TestMethod]
    public void MyTestMethod()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          ImplementationOfCustomLogger.LoggerInstance,
          new NullReferenceException(),
          new LowercasePlugin(),
          new UppercasePlugin()
        };
      ServiceLocator.SetLocatorProvider(() => new Container(_services));
      ServiceLocatorUser _newUser = new ServiceLocatorUser();
      ICustomLogger _logger = _newUser.DataProcessing<ICustomLogger>("AdaptiveProgramming.Composition.UnitTest.Instrumentation.ImplementationOfCustomLogger");
      Assert.IsNotNull(_logger);
      Assert.AreSame(ImplementationOfCustomLogger.LoggerInstance, _logger);
      _logger.Log("Random Text");
      Assert.AreEqual("Random Text", ImplementationOfCustomLogger.LastLog);
    }

    [TestMethod]
    public void WrongKeyTest()
    {
      object[] _services =
        {
          InMemoryLogger.LoggerInstance,
          new LowercasePlugin(),
          new UppercasePlugin(),
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

  internal class ServiceLocatorUser
  {
    public ServiceLocatorUser()
    {
      if (!ServiceLocator.IsLocationProviderSet)
        throw new ActivationException("I cannot compose my stuff because the ServiceLocator.Current is null");
    }

    public TService DataProcessing<TService>()
    {
      IServiceLocator _locator = ServiceLocator.Current;
      return _locator.GetInstance<TService>() ?? throw new ArgumentNullException("Service", "The logger instance is null");
    }

    public TService DataProcessing<TService>(string? fullName)
    {
      IServiceLocator _locator = ServiceLocator.Current;
      return _locator.GetInstance<TService>(fullName) ?? throw new ArgumentNullException("Service", "The service instance is null");
    }

    public void DataProcessingNullReferenceException()
    {
      IServiceLocator _locator = ServiceLocator.Current;
      Exception _exception = _locator.GetInstance<Exception>() ?? throw new ArgumentNullException(nameof(_exception), "The exception instance is null");
      throw _exception;
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

  #region instrumentation

  //Implementation of IPluginContext
  internal class StringContext : IPluginContext
  {
    public StringContext(string currentText)
    {
      m_Text = currentText;
    }

    public string Text { get => m_Text; set => m_Text = value; }

    private string m_Text;
  }

  #endregion instrumentation
}
}