//____________________________________________________________________________________________________________________________________
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
using System.IO;
using TPA.Configuration.UnitTest.XmlCustomData;
using TPA.Configuration.XmlFactory;

namespace TPA.Configuration.UnitTest
{
  [TestClass]
  [DeploymentItem(@"XmlCustomData\", "XmlCustomData")]
  public class XmlFileUnitTest
  {
    [TestMethod]
    public void ReadFileTestMethod1()
    {
      Assert.IsTrue(File.Exists(_fileName));
      catalog _testingData = XmlFile.ReadXmlFile<catalog>(_fileName);
      Assert.IsTrue(File.Exists(_fileName));
      Assert.IsTrue(TestingData.TestTestingData(_testingData));
    }

    [TestMethod]
    public void WriteXmlFileTestMethod1()
    {
      Assert.IsTrue(File.Exists(_fileName));
      File.Delete(_fileName);
      catalog _testingData = TestingData.CreateTestingData();
      Assert.IsNotNull(_testingData);
      XmlFile.WriteXmlFile<catalog>(_testingData, _fileName, FileMode.OpenOrCreate);
      Assert.IsTrue(File.Exists(_fileName));
    }

    const string _fileName = @"XmlCustomData\TestingData.xml";
  }
}