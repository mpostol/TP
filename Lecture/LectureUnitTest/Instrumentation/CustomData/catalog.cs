using System;

namespace Example.Xml.CustomData
{

  /// <summary>
  /// class catalog
  /// </summary>
  [System.SerializableAttribute()]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/CreateXMLFile.xsd", IsNullable = false)]
  public partial class Catalog
  {

    private CDDescription[] cdField;

    /// <summary>
    /// Gets or sets the cd.
    /// </summary>
    /// <value>
    /// The cd.
    /// </value>
    [System.Xml.Serialization.XmlElementAttribute("cd")]
    public CDDescription[] cd
    {
      get
      {
        return this.cdField;
      }
      set
      {
        this.cdField = value;
      }
    }
  }
  /// <summary>
  /// class CDDescription 
  /// </summary>
  [System.SerializableAttribute()]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  public partial class CDDescription : IEquatable<CDDescription>
  {

    #region private
    private string titleField;
    private string artistField;
    private string countryField;
    private string companyField;
    private decimal priceField;
    private ushort yearField;
    #endregion    

    #region object state 
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    /// <uwagi />
    public string title
    {
      get
      {
        return this.titleField;
      }
      set
      {
        this.titleField = value;
      }
    }
    /// <summary>
    /// Gets or sets the artist.
    /// </summary>
    /// <value>The artist.</value>
    public string artist
    {
      get
      {
        return this.artistField;
      }
      set
      {
        this.artistField = value;
      }
    }
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>
    /// The country.
    /// </value>
    public string country
    {
      get
      {
        return this.countryField;
      }
      set
      {
        this.countryField = value;
      }
    }
    /// <summary>
    /// Gets or sets the company.
    /// </summary>
    /// <value>
    /// The company.
    /// </value>
    public string company
    {
      get
      {
        return this.companyField;
      }
      set
      {
        this.companyField = value;
      }
    }
    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>
    /// The price.
    /// </value>
    public decimal price
    {
      get
      {
        return this.priceField;
      }
      set
      {
        this.priceField = value;
      }
    }
    /// <summary>
    /// Gets or sets the year.
    /// </summary>
    /// <value>
    /// The year.
    /// </value>
    public ushort year
    {
      get
      {
        return this.yearField;
      }
      set
      {
        this.yearField = value;
      }
    }
    #endregion

    #region IEquatable<CDDescription>
    public bool Equals(CDDescription other)
    {
      return ($"{other.titleField}, {other.artistField}, {other.countryField}, {other.companyField}, {other.priceField}, {other.yearField}" != $"{titleField}, {artistField}, {countryField}, {companyField}, {priceField}, {yearField}");
    }
    #endregion

  }
}
