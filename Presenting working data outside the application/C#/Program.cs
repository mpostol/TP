
using System.Diagnostics;
using Example.Xml.CustomData;

namespace Example.Xml
{
  class Program
  {
    static void Main( string[] args )
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
      catalog _catalog = new catalog
      {
        cd = new CDDescription[] { _cd1, _cd2 }
      };
      string _fileName = @"CustomData\Catalog.xml";
      Xml.DocumentsFactory.XmlFile.WriteXmlFile<catalog>( _catalog, _fileName, System.IO.FileMode.Create );
      catalog _newPerson = Xml.DocumentsFactory.XmlFile.ReadXmlFile<catalog>( _fileName );
      Debug.Equals( _catalog, _newPerson );
    }
  }
}
