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

      #endregion File Content

      if (!File.Exists(TestFilePath) || File.ReadAllText(TestFilePath) != content)
        File.WriteAllText(TestFilePath, content);
    }

    #endregion test instrumentation
  }
}