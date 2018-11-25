//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TPA.Reflection.DynamicType;

namespace TPA.Reflection.UnitTest.DynamicType
{
  [TestClass]
  public class ReadOnlyFileUnitTest
  {

    [TestMethod]
    [ExpectedException(typeof(FileLoadException))]
    public void CtorNotExistingFileTest()
    {
      ReadOnlyFile _readOnlyFile = new ReadOnlyFile("$$$.%%%");
    }
    [TestMethod]
    public void ContainsPropertyNameTest()
    {
      InitFile();
      dynamic _rFile = new ReadOnlyFile(TestFilePath);
      foreach (string line in _rFile.Customer(StringSearchOption.Contains, true))
        Assert.IsTrue(line.ToUpper().Contains("Customer".ToUpper()));
    }
    [TestMethod]
    public void StartsWithPropertyNameTest()
    {
      InitFile();
      dynamic _rFile = new ReadOnlyFile(TestFilePath);
      foreach (string line in _rFile.Supplier(StringSearchOption.StartsWith, true))
        Assert.IsTrue(line.ToUpper().StartsWith("Supplier".ToUpper()));
    }
    [TestMethod]
    public void EndsWithPropertyNameTest()
    {
      InitFile();
      dynamic _rFile = new ReadOnlyFile(TestFilePath);
      foreach (string line in _rFile.Patrick(StringSearchOption.StartsWith, true))
        Assert.IsTrue(line.ToUpper().EndsWith("Patrick".ToUpper()));
    }

    #region test instrumentation
    private string TestFilePath => "ReadOnlyFileTest.txt";
    private void InitFile()
    {
      #region File Content
      string content = @"List of customers and suppliers  
Supplier: Lucerne Publishing (http://www.lucernepublishing.com/)  
Customer: Preston, Chris  
Customer: Hines, Patrick  
Customer: Cameron, Maria  
Supplier: Graphic Design Institute (http://www.graphicdesigninstitute.com/)   
Supplier: Fabrikam, Inc. (http://www.fabrikam.com/)   
Customer: Seubert, Roxanne  
Supplier: Proseware, Inc. (http://www.proseware.com/)   
Customer: Adolphi, Stephan  
Customer: Koch, Paul  ";
      #endregion
      if (!File.Exists(TestFilePath) || File.ReadAllText(TestFilePath) != content)
        File.WriteAllText(TestFilePath, content);
    }
    #endregion

  }
}
