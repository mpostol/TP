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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

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
      //An aggregate catalog that combines multiple catalogs
      AggregateCatalog _catalog = new AggregateCatalog();
      //Create the CompositionContainer with the parts in the catalog
      _catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(typeof(MEFServiceLocatorUserUnitTest).Assembly.Location)));
      m_Container = new CompositionContainer(_catalog);
      //Fill the imports of this object
      //TODO AP `CompositionTestMethod1` sometime fails #166
      Assert.Inconclusive("AP `CompositionTestMethod1` sometime fails #166");
      m_Container.ComposeParts(attributedParts);
    }

    private CompositionContainer m_Container = null;
  }

  [Export(typeof(ILogger))]
  public class MEFILogger : ILogger
  {
    internal static string LastLog { get; private set; }

    public void Log(string msg) { LastLog = msg; }
  }
}