//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace TP.DataStreams.Serialization
{
  public class CustomFormatter : Formatter
  {

    #region IFormatter
    public override void Serialize(Stream serializationStream, object graph)
    {

      ISerializable _data = (ISerializable)graph;
      SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
      StreamingContext _context = new StreamingContext(StreamingContextStates.File);
      _data.GetObjectData(_info, _context);
      foreach (SerializationEntry _item in _info)
        this.WriteMember(_item.Name, _item.Value);
      XmlWriter _writer = XmlWriter.Create(serializationStream);
      XDocument m_xmlDocument = new XDocument(new XElement("SerializationTest", _values));
      m_xmlDocument.Save(_writer);
      _writer.Flush();
    }

    #region not implemented
    public override object Deserialize(Stream serializationStream)
    {
      throw new NotImplementedException();
    }
    public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    #endregion    
    
    #endregion

    #region private
    List<XElement> _values = new List<XElement>();
    protected override void WriteDouble(double val, string name)
    {
      _values.Add(new XElement(name, val));
    }

    #region not implemented
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
    #endregion

    #endregion

  }
}
