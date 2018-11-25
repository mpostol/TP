
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace TPA.Configuration
{
  public static class ConfigurationManagerUsage
  {
    public static List<string> ReadAllSettings()
    {
      NameValueCollection _appSettings = ConfigurationManager.AppSettings;
      return _appSettings.AllKeys.Select<string, string>(key => _appSettings[key]).ToList<string>();
    }
    public static string ReadSetting(string key)
    {
      NameValueCollection _appSettings = ConfigurationManager.AppSettings;
      return _appSettings[key] ?? "Not Found";
    }
    public static void AddUpdateAppSettings(string key, string value)
    {
      System.Configuration.Configuration _configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      KeyValueConfigurationCollection _settings = _configFile.AppSettings.Settings;
      if (_settings[key] == null)
        _settings.Add(key, value);
      else
        _settings[key].Value = value;
      _configFile.Save(ConfigurationSaveMode.Modified);
      ConfigurationManager.RefreshSection(_configFile.AppSettings.SectionInformation.Name);
    }
  }
}
