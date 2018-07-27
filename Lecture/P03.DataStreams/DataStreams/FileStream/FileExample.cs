//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace TPTP.DataStreams.FileStream
{
  public class FileExample
  {

    /// <summary>
    /// Creates or opens a file for writing UTF-8 encoded text..
    /// </summary>
    /// <param name="name">The name.</param>
    public void CreateTextFile(string name)
    {
      using (Stream _stream = File.Open(name, FileMode.OpenOrCreate, FileAccess.Write))
      {
        FileContent = String.Format(CultureInfo.InvariantCulture, "Today is {0}", DateTime.Now);
        byte[] _content = Encoding.ASCII.GetBytes(FileContent);
        _stream.Write(_content, 0 , _content.Length);
      }
    }

    public string FileContent { get; private set; }

  }
}
