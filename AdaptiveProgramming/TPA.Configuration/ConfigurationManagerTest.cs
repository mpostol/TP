using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Configuration
{
    public class ConfigurationManagerTest
    {
        public string ReadConfig(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);

            return value == string.Empty ? "Not_Found" : value;
        }
    }
}
