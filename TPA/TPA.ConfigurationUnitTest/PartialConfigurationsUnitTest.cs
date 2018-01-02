
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Configuration.MicrosoftExtensions;

namespace TPA.Configuration.UnitTest
{
  [TestClass]
  public class PartialConfigurationsUnitTest
  {
    [TestMethod]
    public void GetConfigurationTestMethod1()
    {
      IConfiguration _configuration = PartialConfigurations.GetInMemoryConfiguration();
      Assert.AreEqual<string>(PartialConfigurations.DefaultConnectionString, _configuration[$"ConnectionString"]);
      Assert.AreEqual<int>(40, _configuration.GetValue<int>("MainWindow:Height"));
      Assert.AreEqual<int>(60, _configuration.GetValue<int>("MainWindow:Width"));
      Assert.AreEqual<int>(0, _configuration.GetValue<int>("MainWindow:Top"));
      Assert.AreEqual<int>(0, _configuration.GetValue<int>("MainWindow:Left"));
      Assert.AreEqual<int>(80, _configuration.GetValue<int>("MainWindow:ScreenBufferSize", 80)); //AppConfiguration:MainWindow:ScreenBufferSize is absent in the configuration
    }
    [TestMethod]
    public void GetSwitchMappingsMyTestMethod()
    {
      Dictionary<string, string> _mappings = PartialConfigurations.GetSwitchMappings(PartialConfigurations.InMemoryConfiguration);
      Assert.AreEqual<string>($"ConnectionString", _mappings["-ConnectionString"]);
      Assert.AreEqual<string>($"MainWindow:Height", _mappings["-Height"]);
      Assert.AreEqual<string>($"MainWindow:Width", _mappings["-Width"]);
      Assert.AreEqual<string>($"MainWindow:Top", _mappings["-Top"]);
      Assert.AreEqual<string>($"MainWindow:Left", _mappings["-Left"]);
    }
    [TestMethod]
    public void GetApplicationConfigurationTestMethod()
    {
      AppConfiguration _configuration = PartialConfigurations.GetApplicationConfiguration(PartialConfigurations.GetInMemoryConfiguration());
      Assert.IsNotNull(_configuration);
      Assert.IsFalse(string.IsNullOrEmpty(_configuration.Profile.UserName));
      Assert.AreEqual<string>(PartialConfigurations.DefaultConnectionString, _configuration.ConnectionString);
      Assert.AreEqual<int>(40, _configuration.MainWindow.Height);
      Assert.AreEqual<int>(60, _configuration.MainWindow.Width);
      Assert.AreEqual<int>(0, _configuration.MainWindow.Top);
      Assert.AreEqual<int>(0, _configuration.MainWindow.Left);
    }
    [TestMethod]
    public void GetConfigurationWithCommanLineTestMethod()
    {
      IConfiguration _configuration = PartialConfigurations.GetInMemoryConfiguration(new string[] { "/Top=42", "-Left=43" });
      Assert.AreEqual<string>(PartialConfigurations.DefaultConnectionString, _configuration[$"ConnectionString"]);
      Assert.AreEqual<int>(40, _configuration.GetValue<int>("MainWindow:Height"));
      Assert.AreEqual<int>(60, _configuration.GetValue<int>("MainWindow:Width"));
      Assert.AreEqual<int>(0, _configuration.GetValue<int>("MainWindow:Top"));  //the value hasn't been overwritten by the args
      Assert.AreEqual<int>(43, _configuration.GetValue<int>("MainWindow:Left")); //the value has been overwritten by the args
      Assert.AreEqual<int>(80, _configuration.GetValue<int>("MainWindow:ScreenBufferSize", 80)); //AppConfiguration:MainWindow:ScreenBufferSize is absent in the configuration
    }
    [TestMethod]
    public void GetExtendedConfigurationWithCommanLineTestMethod()
    {
      IConfiguration _configuration = PartialConfigurations.GetInMemoryConfiguration(new string[] { "/Top=42", "-Left=43", "/ScreenBufferSize=123" });
      Assert.AreEqual<string>(PartialConfigurations.DefaultConnectionString, _configuration[$"ConnectionString"]);
      Assert.AreEqual<int>(40, _configuration.GetValue<int>("MainWindow:Height"));
      Assert.AreEqual<int>(60, _configuration.GetValue<int>("MainWindow:Width"));
      Assert.AreEqual<int>(0, _configuration.GetValue<int>("MainWindow:Top"));  //the value has been overwritten by the args
      Assert.AreEqual<int>(43, _configuration.GetValue<int>("MainWindow:Left")); //the value has been overwritten by the args
      Assert.AreEqual<int>(80, _configuration.GetValue<int>("MainWindow:ScreenBufferSize", 80)); //AppConfiguration:MainWindow:ScreenBufferSize is absent in the configuration
    }
  }
}
