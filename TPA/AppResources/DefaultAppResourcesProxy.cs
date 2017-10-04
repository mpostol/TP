using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppResources.Interfaces;

namespace AppResources
{
    public class DefaultAppResourcesProxy : IAppResourcesProxy
    {
        public string GetString(string key) 
            => Resources.AppResources.ResourceManager.GetString(key);
    }
}
