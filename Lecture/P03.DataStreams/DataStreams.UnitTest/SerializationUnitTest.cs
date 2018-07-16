using Microsoft.VisualStudio.TestTools.UnitTesting;
using Example.Xml.CustomData;
using Example.Xml.DocumentsFactory;

namespace TP.Lecture.UnitTest
{
  [TestClass]
  public class SerializationUnitTest
  {
    [TestMethod]
    public void TestMethod1()
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
      _cd1.Equals(_cd2);
      Catalog _catalog = new Catalog
      {
        cd = new CDDescription[] { _cd1, _cd2 }
      };
      string _fileName = @"Instrumentation\CustomData\catalog.xml";
      XmlFile.WriteXmlFile<Catalog>(_catalog, _fileName, System.IO.FileMode.Create);
      Catalog _newPerson = XmlFile.ReadXmlFile<Example.Xml.CustomData.Catalog>(_fileName);
      Assert.IsFalse(_catalog.cd[0].Equals(_newPerson.cd[0]));
      Assert.IsFalse(_catalog.cd[1].Equals(_newPerson.cd[1]));

    }
  }
}
