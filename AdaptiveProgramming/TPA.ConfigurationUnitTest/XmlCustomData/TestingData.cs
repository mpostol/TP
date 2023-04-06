//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPA.Configuration.UnitTest.XmlCustomData
{
  internal static class TestingData
  {
    internal static catalog CreateTestingData()
    {
      int _identifier = 0;
      catalog _ret = new catalog
      {
        cd = new CDDescription[]
        {
           CreateCDDescription(_identifier ++),
           CreateCDDescription(_identifier ++),
           CreateCDDescription(_identifier ++),
           CreateCDDescription(_identifier ++)
        }
      };
      return _ret;
    }

    private static CDDescription CreateCDDescription(int identifier)
    {
      return new CDDescription() { artist = $"artist #{identifier}", company = $"company #{identifier}", country = $"country #{identifier}", price = 123, title = $"title #{identifier}", year = 2017 };
    }

    internal static bool TestTestingData(catalog testingData)
    {
      Assert.IsNotNull(testingData);
      Assert.AreEqual<int>(4, testingData.cd.Length);
      //TODO add more detailed coparation
      return true;
    }
  }
}