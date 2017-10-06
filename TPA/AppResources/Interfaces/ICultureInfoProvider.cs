using System.Globalization;

namespace AppResources.Interfaces
{
  public interface ICultureInfoProvider
  {
    CultureInfo RequestedCulture { get; }

  }
}
