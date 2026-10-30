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

using System.ComponentModel.Composition.Hosting;

namespace TPA.Composition.UnitTest
{
  //[TestClass]
  //public class MEFServiceLocatorUserUnitTest
  //{
  //  //[TestMethod]
  //  public void CompositionTestMethod1()
  //  {
  //    MEFServiceLocatorUser _newInstance = new MEFServiceLocatorUser();
  //    //Assert.IsNull(_newInstance.Logger);
  //    ComposeParts(_newInstance);
  //    Assert.IsNotNull(_newInstance.logger);
  //    _newInstance.DataProcessing();
  //    Assert.IsFalse(string.IsNullOrEmpty(MEFILogger.LastLog));
  //  }

  //  #region private instrumentation

  //  private void ComposeParts(object attributedParts)
  //  {
  //    AggregateCatalog _catalog = new AggregateCatalog();
  //    _catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(typeof(MEFServiceLocatorUserUnitTest).Assembly.Location)));
  //    m_Container = new CompositionContainer(_catalog);
  //    Assert.Inconclusive("AP `CompositionTestMethod1` sometime fails #166");
  //    // m_Container.ComposeParts(attributedParts);
  //  }
  //  private CompositionContainer? m_Container = null;

  //  #endregion
  //}

  public class ImplementationOfCustomLogger : ICustomLogger
  {

    internal static string? LastLog { get; private set; }

    #region ICustomLogger
    public void Log(string msg) { LastLog = msg; }
    #endregion  
  }
}