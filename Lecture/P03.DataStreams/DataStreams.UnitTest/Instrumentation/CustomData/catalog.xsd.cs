//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using TP.Lecture.Serialization;

namespace Example.Xml.CustomData
{
  /// <summary>
  /// class catalog
  /// </summary>
  public partial class Catalog: IStylesheetNameProvider
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
  }
}
