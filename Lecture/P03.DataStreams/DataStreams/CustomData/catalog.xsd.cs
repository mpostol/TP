//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Example.Xml.DocumentsFactory;

namespace Example.Xml.CustomData
{
  /// <summary>
  /// class catalog
  /// </summary>
  public partial class catalog: IStylesheetNameProvider
  {
    #region IStylesheetNameProvider Members
    /// <summary>
    /// The stylesheet name
    /// </summary>
    public string StylesheetNmane
    {
      get { return "catalog.xslt"; }
    }
    #endregion
  }
}
