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
using System;

namespace TPD.AsynchronousProgramming.FileSystemWatcherObservable
{
  [TestClass]
  [DeploymentItem(@"TestingData\", "TestingData")]
  public class DataEntityUnitTest
  {
    #region test methods

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void ReadValueArgumentOutOfRangeTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      float _value = _instance.ReadValue<float>(8);
    }

    [TestMethod]
    public void ReadValueStringTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      string _value = _instance.ReadValue<string>(0);
      Assert.AreEqual<string>("09-12-16", _value);
      _value = _instance.ReadValue<string>(1);
      Assert.AreEqual<string>("09:24:02", _value);
      _value = _instance.ReadValue<string>(2);
      Assert.AreEqual<string>("26.9", _value);
      _value = _instance.ReadValue<string>(3);
      Assert.AreEqual<string>("1368", _value);
    }

    [TestMethod]
    public void ReadValueFloatTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      float _value = _instance.ReadValue<float>(2);
      Assert.AreEqual<float>(26.9f, _value);
      _value = _instance.ReadValue<float>(3);
      Assert.AreEqual<float>(1368f, _value);
    }

    [TestMethod]
    public void ReadValueLongTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      long _value = _instance.ReadValue<long>(3);
      Assert.AreEqual<long>(1368, _value);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ReadValueLongFormatExceptionTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      long _value = _instance.ReadValue<long>(2);
    }

    [TestMethod]
    public void ReadValueIntTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      int _value = _instance.ReadValue<int>(3);
      Assert.AreEqual<long>(1368, _value);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ReadValueIntFormatExceptionTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      object _value = _instance.ReadValue<int>(0);
    }

    [TestMethod]
    public void ReadValueShortTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      short _value = _instance.ReadValue<short>(3);
      Assert.AreEqual<long>(1368, _value);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ReadValueShortFormatExceptionTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      short _value = _instance.ReadValue<short>(2);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ReadValueWrongFormatTest()
    {
      DataEntity _instance = null;
      DataEntity.ReadFile(x => _instance = x, DateTime.Now, GetData());
      float _value = _instance.ReadValue<float>(0);
    }

    [TestMethod]
    public void ConstructorTestMethod()
    {
      IDataEntity _instance = DataEntity.ReadFile(m_FileName, new DateTime(2017, 05, 27), ",");
      Assert.IsNotNull(_instance);
      Assert.AreEqual<DateTime>(new DateTime(2017, 05, 27), _instance.TimeStamp);
      CollectionAssert.AreEqual(_line, _instance.Tags);
    }

    #endregion test methods

    #region instrumentation

    private static string[] GetData()
    {
      return new string[] { "09-12-16", "09:24:02", "26.9", "1368", "09-12-16", "09:24:02", "26.9", "1368" };
    }

    private const string m_FileName = @"TestingData\g1765xa1.1";

    private readonly string[] _line = new string[]
    {
      "09-12-16", "09:24:02", " 26.9", " 26.2", " 25.4", " 28.9", " 25.7", " 28.2", " 27.4", " 22.5",
      " 21.8",    " 22.5",    " 22.5", " 1368", "  900", " 1500", " 87",   " 85",   " 87",   "   59",
      "   20",    "   85",    "   85", "   60", "   60", " 21.8", " 20.3", " 23.8", " 14.7", " 14.3",
      "  6",      "  0",      "  0",   " 70",   "  5.8", " 84",   "  4.8", " 14.5", ""
     };

    #endregion instrumentation
  }
}