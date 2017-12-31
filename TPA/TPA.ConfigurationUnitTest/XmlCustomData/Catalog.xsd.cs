using TPA.Configuration.XmlFactory;

namespace TPA.Configuration.UnitTest.XmlCustomData
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
