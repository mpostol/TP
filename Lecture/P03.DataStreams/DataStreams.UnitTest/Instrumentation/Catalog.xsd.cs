//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________


using System.Diagnostics;
using TP.DataStreams.Serialization;

namespace Example.Xml.CustomData
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
      CDDescription _cd1 = new CDDescription()
      {
        artist = "Bob Dylan",
        title = "Empire Burlesque",
        country = "USA",
        company = "Columbia",
        price = 10.90M,
        year = 1985,
      };
      CDDescription _cd2 = new CDDescription
      {
        title = "Hide your heart",
        artist = "Bonnie Tyler",
        country = "UK",
        company = "CBS Records",
        price = 9.90M,
        year = 1988
      };
      cd = new CDDescription[] { _cd1, _cd2 };
    }
  }
}
