using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppResources.Interfaces;

namespace AppResources
{
    public class AppResourcesProxy : IAppResourcesProxy
    {
        private readonly ICultureInfoProvider _cultureInfoProvider;

        public AppResourcesProxy(ICultureInfoProvider cultureInfoProvider)
        {
            _cultureInfoProvider = cultureInfoProvider;
        }

        public string GetString(string key) =>
            Resources.AppResources.ResourceManager.GetString(key, _cultureInfoProvider.RequestedCulture);
    }
}
