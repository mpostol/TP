//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TP.DataStreams.FileAndStream;

namespace TP.DataStreams
{
  [TestClass]
  public class FileStreamUnitTest
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