
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TPA.Configuration.XmlFactory
{
  /// <summary>
  /// Provides static methods for serialization objects into XML documents and writing the XML document to a file.
  /// </summary>
  public static class XmlFile
  {

    #region public
    /// <summary>
    /// Serializes the specified <paramref name="dataObject"/> and writes the XML document to a file.
    /// </summary>
    /// <typeparam name="type">The type of the root object to be serialized and saved in the file.</typeparam>
    /// <param name="dataObject">The object containing working data to be serialized and saved in the file.</param>
    /// <param name="path">A relative or absolute path for the file containing the serialized object.</param>
    /// <param name="mode">Specifies how the operating system should open a file <see cref="FileMode"/>.</param>
    /// <param name="stylesheetName">Name of the stylesheet document.</param>
    /// <exception cref="System.ArgumentNullException">
    /// path
    /// or
    /// dataObject
    /// or
    /// stylesheetName
    /// </exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2202:Do not dispose objects multiple times" )]
    public static void WriteXmlFile<type>( type dataObject, string path, FileMode mode, string stylesheetName )
    {
      if ( string.IsNullOrEmpty( path ) )
        throw new ArgumentNullException("path");
      if ( string.IsNullOrEmpty( stylesheetName ) )
        throw new ArgumentNullException( "stylesheetName" );
      if ( dataObject == null )
        throw new ArgumentNullException( "content" );
      XmlSerializer _srlzr = new XmlSerializer( typeof( type ) );
      XmlWriterSettings _setting = new XmlWriterSettings()
      {
        Indent = true,
        IndentChars = "  ",
        NewLineChars = "\r\n"
      };
      using ( FileStream _docStrm = new FileStream( path, mode, FileAccess.Write ) )
      using ( XmlWriter _writer = XmlWriter.Create( _docStrm, _setting ) )
      {
        _writer.WriteProcessingInstruction( "xml-stylesheet", "type=\"text/xsl\" " + String.Format( "href=\"{0}\"", stylesheetName ) );
        _srlzr.Serialize( _writer, dataObject );
      }
    }
    /// <summary>
    /// Serializes the specified <paramref name="dataObject"/> and writes the XML document to a file.
    /// </summary>
    /// <typeparam name="type">The type of the object to be serialized and saved in the file.</typeparam>
    /// <param name="dataObject">The object containing working data to be serialized and saved in the file.</param>
    /// <param name="path">A relative or absolute path for the file containing the serialized object.</param>
    /// <param name="mode">Specifies how the operating system should open a file.</param>
    public static void WriteXmlFile<type>( type dataObject, string path, FileMode mode )
      where type: IStylesheetNameProvider
    {
      XmlFile.WriteXmlFile<type>(dataObject, path, mode, dataObject.StylesheetNmane);
    }
    /// <summary>
    /// Reads an XML document from the file <paramref name="path"/> and deserializes its content to returned object.
    /// </summary>
    /// <typeparam name="type">The type of the object to be deserialized and saved in the file.</typeparam>
    /// <param name="path">A relative or absolute path for the file containing the serialized object.</param>
    /// <returns>An object containing working data retrieved from an XML file.</returns>
    /// <exception cref="System.ArgumentNullException">path</exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2202:Do not dispose objects multiple times" )]
    public static type ReadXmlFile<type>( string path )
    {
      if ( string.IsNullOrEmpty( path ) )
        throw new ArgumentNullException("path");
      type _content = default( type );
      XmlSerializer _srlzr = new XmlSerializer( typeof( type ) );
      using ( FileStream _docStrm = new FileStream( path, FileMode.Open, FileAccess.Read ) )
      using ( XmlReader _writer = XmlReader.Create( _docStrm ) )
        _content = (type)_srlzr.Deserialize( _writer );
      return _content;
    }
    #endregion

  }
}
