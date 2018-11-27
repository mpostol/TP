using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
