
using AppResources.Interfaces;

namespace AppResources
{
  public class DefaultAppResourcesProxy : IAppResourcesProxy
  {
    public string GetString(string key)
        => Resources.AppResources.ResourceManager.GetString(key);
  }
}
