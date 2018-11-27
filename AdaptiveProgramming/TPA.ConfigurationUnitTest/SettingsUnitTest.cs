
using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Configuration.UnitTest
{
  [TestClass]
  public class SettingsUnitTest
  {
    [TestMethod]
    public void ConfigurationFileExistsTest()
    {
      File.Exists("TPA.ConfigurationUnitTest.dll");
      File.Exists("TPA.ConfigurationUnitTest.dll.config");
    }
    [TestMethod]
    public void LibrarySettingsTest()
    {
      Assert.AreEqual<String>("SettingString", global::TPA.Configuration.Properties.Settings.Default.SettingString);
      Assert.AreEqual<Color>(Color.Red, global::TPA.Configuration.Properties.Settings.Default.SettingColor);
      Assert.AreEqual<String>("SettingString", global::TPA.Configuration.Properties.Settings.Default.SettingString);
    }

    [TestMethod]
    public void LibraryAdditionalSettingsRest()
    {
      Assert.AreEqual<String>("SettingString in the AdditionalSettings", AdditionalSettings.Default.SettingString);
    }
    [TestMethod]
    public void UnitTestSettingsTest()
    {
      Assert.AreEqual<String>("UTString", Properties.Settings.Default.UTString);
    }
  }
}
