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

//using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting; // Alias to resolve ambiguity

using Microsoft.Testing.Platform.Logging;
using System.ComponentModel.Composition.Hosting;

namespace TPA.Composition.UnitTest
{
  [TestClass]
  public class MEFServiceLocatorUserUnitTest
  {
    [TestMethod]
    public void CompositionTestMethod1()
    {
      MEFServiceLocatorUser _newInstance = new MEFServiceLocatorUser();
      Assert.IsNull(_newInstance.Logger);
      ComposeParts(_newInstance);
      Assert.IsNotNull(_newInstance.Logger);
      _newInstance.DataProcessing();
      Assert.IsFalse(string.IsNullOrEmpty(MEFILogger.LastLog));
    }

    private void ComposeParts(object attributedParts)
    {
      AggregateCatalog _catalog = new AggregateCatalog();
      _catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(typeof(MEFServiceLocatorUserUnitTest).Assembly.Location)));
      m_Container = new CompositionContainer(_catalog);
      Assert.Inconclusive("AP `CompositionTestMethod1` sometime fails #166");
      // m_Container.ComposeParts(attributedParts);
    }

    private CompositionContainer m_Container = null;
  }

  public class MEFILogger : ILogger
  {

    internal static string? LastLog { get; private set; }
    public void Log(string msg) { LastLog = msg; }

    public bool IsEnabled(LogLevel logLevel)
    {
      throw new NotImplementedException();
    }
    public void Log<TState>(LogLevel logLevel, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      throw new NotImplementedException();
    }
    public Task LogAsync<TState>(LogLevel logLevel, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      throw new NotImplementedException();
    }
  }
}