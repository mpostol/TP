
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
