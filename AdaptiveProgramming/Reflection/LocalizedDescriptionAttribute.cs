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

using AppResources;
using AppResources.Interfaces;
using System.ComponentModel;

namespace TPA.Reflection
{
  public class LocalizedDescriptionAttribute : DescriptionAttribute
  {
    /// <summary>
    /// Provider for localized resources for all <see cref="LocalizedDescriptionAttribute"/>
    /// </summary>
    public static IAppResourcesProxy ResourcesProxy { get; set; } = new DefaultAppResourcesProxy();

    /// <summary>
    /// Returns original localization key passed when creating this instance.
    /// </summary>
    public string LocalizationKey { get; }

    /// <summary>
    /// Initializes new instance of <see cref="LocalizedDescriptionAttribute"/> with localized description defined by passed <see cref="description"/>
    /// </summary>
    /// <param name="description">Translation key value.</param>
    public LocalizedDescriptionAttribute(string description)
        : base(ResourcesProxy.GetString(description))
    {
      LocalizationKey = description;
    }
  }
}