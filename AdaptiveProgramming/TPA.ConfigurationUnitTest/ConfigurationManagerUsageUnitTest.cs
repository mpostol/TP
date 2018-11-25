//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Configuration.UnitTest
{
  [TestClass]
  public class ConfigurationManagerUsageUnitTest
  {
    [TestInitialize]
    public void TestInitializeMethod()
    {
      File.Copy("TPA.ConfigurationUnitTest.dll", "TPA.ConfigurationUnitTest.dll.bak", true);
    }
    [TestCleanup]
    public void TestCleanupMethod()
    {
      //Exception is thrown because the file in in use
      //File.Copy("TPA.ConfigurationUnitTest.dll.bak", "TPA.ConfigurationUnitTest.dll", true);
    }
    [TestMethod]
    public void ReadWriteTestMethod()
    {
      Assert.Inconclusive("The test passes only once after build because it modifies the configuration file");
      CollectionAssert.AreEqual(new string[] { "May 5, 2014", "May 6, 2014" }, ConfigurationManagerUsage.ReadAllSettings());
      Assert.AreEqual<string>("May 5, 2014", ConfigurationManagerUsage.ReadSetting("Setting1"));
      Assert.AreEqual<string>("Not Found", ConfigurationManagerUsage.ReadSetting("NotValid"));
      ConfigurationManagerUsage.AddUpdateAppSettings("NewSetting", "May 7, 2014");
      ConfigurationManagerUsage.AddUpdateAppSettings("Setting1", "May 8, 2014");
      CollectionAssert.AreEqual(new string[] { "May 8, 2014", "May 6, 2014", "May 7, 2014" }, ConfigurationManagerUsage.ReadAllSettings());
    }
  }
}
