
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Configuration.UnitTest
{
  [TestClass]
  public class ConfigurationManagerUsageUnitTest
  {
    [TestMethod]
    public void ReadWriteTestMethod()
    {
      CollectionAssert.AreEqual(new string[] { "May 5, 2014", "May 6, 2014" }, ConfigurationManagerUsage.ReadAllSettings());
      Assert.AreEqual<string>("May 5, 2014", ConfigurationManagerUsage.ReadSetting("Setting1"));
      Assert.AreEqual<string>("Not Found", ConfigurationManagerUsage.ReadSetting("NotValid"));
      ConfigurationManagerUsage.AddUpdateAppSettings("NewSetting", "May 7, 2014");
      ConfigurationManagerUsage.AddUpdateAppSettings("Setting1", "May 8, 2014");
      CollectionAssert.AreEqual(new string[] { "May 8, 2014", "May 6, 2014", "May 7, 2014" }, ConfigurationManagerUsage.ReadAllSettings());
    }
  }
}
