//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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