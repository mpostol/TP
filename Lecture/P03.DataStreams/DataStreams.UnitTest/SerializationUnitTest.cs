//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Example.Xml.CustomData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.Lecture.Serialization;

namespace TP.DataStreams
{
  [TestClass]
  public class SerializationUnitTest
  {
    [TestMethod]
    public void ReadWRiteTest()
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
      Assert.IsFalse(_cd1.Equals(_cd2));
      Catalog _catalog = new Catalog
      {
        cd = new CDDescription[] { _cd1, _cd2 }
      };
      string _fileName = @"Instrumentation\CustomData\catalog.xml";
      XmlFile.WriteXmlFile<Catalog>(_catalog, _fileName, System.IO.FileMode.Create);
      Catalog _newPerson = XmlFile.ReadXmlFile<Catalog>(_fileName);
      Assert.IsTrue(_catalog.cd[0].Equals(_newPerson.cd[0]));
      Assert.IsTrue(_catalog.cd[1].Equals(_newPerson.cd[1]));

    }
  }
}
