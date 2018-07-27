//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TPTP.DataStreams.FileStream;

namespace TP.DataStreams
{
  [TestClass]
  public class FileStreamUnitTest
  {
    [TestClass]
    public class FileTestClass
    {
      [TestMethod]
      public void FileTestMethod()
      {
        string _fileName = "TestFileName.txt";
        FileExample _fileWrapper = new FileExample();
        _fileWrapper.CreateTextFile(_fileName);
        using (StreamReader _stream = File.OpenText(_fileName))
        {
          string _content = _stream.ReadToEnd();
          Assert.AreEqual(_content, _fileWrapper.FileContent);
        }
      }
    }
  }
}

//Message: Assert.AreEqual failed.Expected:<Today is 07/27/2018 14:51:07 ?>. Actual:<Today is 07/27/2018 14:51:07 ą>. 