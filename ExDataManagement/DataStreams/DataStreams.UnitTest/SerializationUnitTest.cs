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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using TP.ExDM.DataStreams.Instrumentation;
using TP.ExDM.DataStreams.Serialization;

namespace TP.ExDM.DataStreams
{
  [TestClass]
  public class SerializationUnitTest
  {
    [TestMethod]
    public void SelfControlSerializationTest()
    {
      ISerializable _objectToSerialize = new SelfControlSerialization(987654321.123, 123456789.987);
      CustomFormatter _formatter = new CustomFormatter();
      const string _fileName = "test.xml";
      File.Delete(_fileName);
      using (Stream _stream = new FileStream("test.xml", FileMode.Create))
        _formatter.Serialize(_stream, _objectToSerialize);
      FileInfo _info = new FileInfo(_fileName);
      Assert.IsTrue(_info.Exists);
      Assert.IsTrue(_info.Length >= 100, $"The file length is {_info.Length}");
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
      Assert.IsNotNull(_catalog2Write.CD);
      string _fileName = @"catalog.xml";
      XmlFile.WriteXmlFile<Catalog>(_catalog2Write, _fileName, FileMode.Create);
      Catalog _recoveredCatalog = XmlFile.ReadXmlFile<Catalog>(_fileName);
      Assert.IsNotNull(_recoveredCatalog);
      Assert.AreEqual<int>(_catalog2Write.CD.Length, _recoveredCatalog.CD.Length);
      Assert.IsTrue(_catalog2Write.CD[0] == _recoveredCatalog.CD[0]);
      Assert.IsTrue(_catalog2Write.CD[1] == _recoveredCatalog.CD[1]);
    }
  }
}