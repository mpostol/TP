
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Composition.Plugins.PluginContract;

namespace TPA.Composition.UnitTest
{
  [TestClass]
  public class PluginTests
  {
    [TestMethod]
    public void LoadPluginsTest()
    {
      //Load plugins from <ApplicationName>.config
      //VS automatically copy App.config to <ApplicationName>.config
      //Requires reference to System.Configuration
      List<IPlugin> _plugins = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
      Assert.AreEqual(2, _plugins.Count);
      Assert.AreEqual("Uppercase Plugin", _plugins[0].Name);
      Assert.AreEqual("Lowercase Plugin", _plugins[1].Name);
    }
    [TestMethod]
    public void UppercasePluginTest()
    {
      List<IPlugin> _plugins = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
      StringContext _stringContext = new StringContext("This is only Rock'n'roll");
      _plugins[0].PerformAction(_stringContext); //Perform operation on data
      Assert.AreEqual("THIS IS ONLY ROCK'N'ROLL", _stringContext.Text);
    }
    [TestMethod]
    public void LowercasePluginTest()
    {
      List<IPlugin> _plugins = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
      StringContext _stringContext = new StringContext("ART OF FLYING");
      _plugins[1].PerformAction(_stringContext); //Perform operation on data
      Assert.AreEqual("art of flying", _stringContext.Text);
    }

    #region instrumentation
    //Implementation of IPluginContext
    internal class StringContext : IPluginContext
    {
      public StringContext(string currentText)
      {
        this.m_Text = currentText;
      }
      public string Text { get => m_Text; set => m_Text = value; }

      private string m_Text;
    }
    #endregion

  }
}
