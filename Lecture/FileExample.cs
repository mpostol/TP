using System;
using System.Globalization;
using System.IO;

namespace TP.Lecture
{
  public class FileExample
  {
    /// <summary>
    /// Creates or opens a file for writing UTF-8 encoded text..
    /// </summary>
    /// <param name="name">The name.</param>
    public void CreateTextFile( string name )
    {
      using ( StreamWriter _stream = File.CreateText( name ) )
      {
        FileContent = String.Format( CultureInfo.InvariantCulture, "today is {0}", DateTime.Now );
        _stream.Write( m_FileContent ); 
      }
    }
    public string FileContent
    {
      get { return m_FileContent; }
      private set { m_FileContent = value; }
    }

    private string m_FileContent;

  }
}
