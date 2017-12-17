
using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Configuration.UnitTest
{
  [TestClass]
  public class SettingsUnitTest
  {
    [TestMethod]
    public void SettingsTest()
    {
      Assert.AreEqual<String>("SettingString", Properties.Settings.Default.SettingString);
      Assert.AreEqual<Color>(Color.Red, Properties.Settings.Default.SettingColor);
    }
  }
}
