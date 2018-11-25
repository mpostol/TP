using System.Globalization;
using AppResources.Interfaces;

namespace TPA.Reflection.UnitTest.Providers
{
  public class CustomCultureProvider : ICultureInfoProvider
  {
    public CultureInfo RequestedCulture { get; }

    public CustomCultureProvider(CultureInfo customCulture)
    {
      RequestedCulture = customCulture;
    }
  }
}
