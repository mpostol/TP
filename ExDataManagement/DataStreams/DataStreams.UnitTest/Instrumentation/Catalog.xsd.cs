﻿//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System.Diagnostics;
using System.Xml.Serialization;
using TP.ExDM.DataStreams.Serialization;

namespace TP.ExDM.DataStreams.Instrumentation
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
    [XmlIgnore]
    public string StylesheetName { get; set; } = "catalog.xslt";
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
  partial class CatalogCD
  {
    public static bool operator ==(CatalogCD left, CatalogCD right)
    {
      return left.Equals(right);
    }
    public static bool operator !=(CatalogCD left, CatalogCD right)
    {
      return !left.Equals(right);
    }
    public override bool Equals(object obj)
    {
      CatalogCD _catalogCD = obj as CatalogCD ?? throw new System.ArgumentException(nameof(obj), "wrong parameter type");
      return ToString() == _catalogCD.ToString();
    }
    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }
    public override string ToString()
    {
      return $"{Artist}, {Company}, {Country}, {Price}, {Title}, {Year}";
    }
  }

}
