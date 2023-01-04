//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.InformationComputation.PartialDefinitions
{
  [TestClass]
  public class CatalogTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      Catalog newCatalog = GenerateTestingData();
      Assert.IsNotNull(newCatalog.CD);
      Assert.AreEqual<int>(2, newCatalog.CD.Length);
    }

    #region instrumentation

    private Catalog GenerateTestingData()
    {
      CatalogCD entry1 = new CatalogCD()
      {
        Artist = "Bob Dylan",
        Title = "Empire Burlesque",
        Country = "USA",
        Company = "Columbia",
        Price = 10.90M,
        Year = 1985,
      };
      CatalogCD entry2 = new CatalogCD
      {
        Title = "Hide your heart",
        Artist = "Bonnie Tyler",
        Country = "UK",
        Company = "CBS Records",
        Price = 9.90M,
        Year = 1988
      };
      Catalog catalogInstnace = new Catalog();
      catalogInstnace.CD = new CatalogCD[] { entry1, entry2 };
      return catalogInstnace;
    }

    #endregion instrumentation
  }
}