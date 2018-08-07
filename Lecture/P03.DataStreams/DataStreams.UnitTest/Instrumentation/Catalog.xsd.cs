//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________


using System.Diagnostics;
using TP.DataStreams.Serialization;

namespace TP.DataStreams.Instrumentation
{
  /// <summary>
  /// class catalog
  /// </summary>
  public partial class Catalog : IStylesheetNameProvider
  {
    #region IStylesheetNameProvider Members
    /// <summary>
    /// The stylesheet name
    /// </summary>
    public string StylesheetName
    {
      get { return "catalog.xslt"; }
    }
    #endregion
    [Conditional("DEBUG")]
    internal void AddTestingData()
    {
      CatalogCD _cd1 = new CatalogCD()
      {
        Artist = "Bob Dylan",
        Title = "Empire Burlesque",
        Country = "USA",
        Company = "Columbia",
        Price = 10.90M,
        Year = 1985,
      };
      CatalogCD _cd2 = new CatalogCD
      {
        Title = "Hide your heart",
        Artist = "Bonnie Tyler",
        Country = "UK",
        Company = "CBS Records",
        Price = 9.90M,
        Year = 1988
      };
      CD = new CatalogCD[] { _cd1, _cd2 };
    }
  }
}
