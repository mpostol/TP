//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Globalization;
using System.IO;

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
      using (StreamWriter _stream = File.CreateText(name))
      {
        FileContent = String.Format(CultureInfo.InvariantCulture, "today is {0}", DateTime.Now);
        _stream.Write(FileContent);
      }

    }

    public string FileContent { get; private set; }

  }
}
