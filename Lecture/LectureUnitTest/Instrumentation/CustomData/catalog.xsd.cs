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
