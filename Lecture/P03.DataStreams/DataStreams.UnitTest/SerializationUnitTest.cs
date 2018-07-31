//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Example.Xml.CustomData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TP.DataStreams.Serialization;
using TP.Lecture.Serialization;

namespace TP.DataStreams
{
  [TestClass]
  public class SerializationUnitTest
  {
    [TestMethod]
    public void SerializeTestMethod()
    {
      ISerializable _objectToSerialize = new CustomSerialization(987654321.123, 123456789.987);
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
    class CustomFormatter : Formatter
    {
      public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
      public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
      public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

      public override object Deserialize(Stream serializationStream)
      {
        throw new NotImplementedException();
      }

      public override void Serialize(Stream serializationStream, object graph)
      {

        ISerializable _data = (ISerializable)graph;
        SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
        StreamingContext _context = new StreamingContext(StreamingContextStates.File);
        _data.GetObjectData(_info, _context);
        foreach (SerializationEntry _item in _info)
          this.WriteMember(_item.Name, _item.Value);
        XmlWriter _writer = XmlWriter.Create(serializationStream);
        XDocument m_xmlDocument = new XDocument(new XElement( "SerializationTest",  _values));
        m_xmlDocument.Save(_writer);
        _writer.Flush();
      }
      List<XElement> _values = new List<XElement>();
      protected override void WriteArray(object obj, string name, Type memberType)
      {
        throw new NotImplementedException();
      }

      protected override void WriteBoolean(bool val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteByte(byte val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteChar(char val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteDateTime(DateTime val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteDecimal(decimal val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteDouble(double val, string name)
      {
        _values.Add( new XElement(name, val));
      }

      protected override void WriteInt16(short val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteInt32(int val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteInt64(long val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteObjectRef(object obj, string name, Type memberType)
      {
        throw new NotImplementedException();
      }

      protected override void WriteSByte(sbyte val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteSingle(float val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteTimeSpan(TimeSpan val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteUInt16(ushort val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteUInt32(uint val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteUInt64(ulong val, string name)
      {
        throw new NotImplementedException();
      }

      protected override void WriteValueType(object obj, string name, Type memberType)
      {
        throw new NotImplementedException();
      }
    }
    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e6d687d7-e0e8-4f46-ad88-fe764cd18c3b/implemant-iformatter-interface?forum=csharpgeneral
    //https://stackoverflow.com/questions/12566946/serialize-a-generic-object-to-ini-text-file-implementing-a-custom-iformatter
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
