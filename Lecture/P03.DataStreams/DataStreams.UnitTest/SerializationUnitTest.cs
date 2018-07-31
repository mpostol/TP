//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Example.Xml.CustomData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using TP.DataStreams.Instrumentation;
using TP.DataStreams.Serialization;

namespace TP.DataStreams
{
  [TestClass]
  public class SerializationUnitTest
  {
    [TestMethod]
    public void SerializeTestMethod()
    {
      ISerializable _objectToSerialize = new SelfControlSerialization(987654321.123, 123456789.987);
      CustomFormatter _formatter = new CustomFormatter();
      const string _fileName = "test.xml";
      File.Delete(_fileName);
      using (FileStream _stream = new FileStream("test.xml", FileMode.Create))
        _formatter.Serialize(_stream, _objectToSerialize);
      FileInfo _info = new FileInfo(_fileName);
      Assert.IsTrue(_info.Exists);
      Assert.IsTrue(_info.Length >= 100, $"The file length is {_info.Length  }");
      string _fileContent = File.ReadAllText(_fileName, Encoding.UTF8);
      Debug.Write(_fileContent);
    }

    [TestMethod]
    public void ReadWRiteTest()
    {

#if !DEBUG
      Assert.Inconclusive("The test can be executed only in debug configuration");
#endif
      Catalog _catalog2Write = new Catalog();
      _catalog2Write.AddTestingData();
      Assert.IsNotNull(_catalog2Write.cd);
      string _fileName = @"Instrumentation\CustomData\catalog.xml";
      XmlFile.WriteXmlFile<Catalog>(_catalog2Write, _fileName, FileMode.Create);
      Catalog _recoveredCatalog = XmlFile.ReadXmlFile<Catalog>(_fileName);
      Assert.IsTrue(_catalog2Write.cd[0].Equals(_recoveredCatalog.cd[0]));
      Assert.IsTrue(_catalog2Write.cd[1].Equals(_recoveredCatalog.cd[1]));

    }

  }
}
