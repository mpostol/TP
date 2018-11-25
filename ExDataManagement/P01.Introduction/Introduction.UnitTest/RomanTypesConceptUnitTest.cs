#pragma warning disable CS0219 // Variable is assigned but its value is never used
//___________________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.Introduction
{

  [TestClass]
  public class RomanTypesConceptUnitTest
  {
    [TestMethod]
    public void TypesCompatibilityTest()
    {
      long _arabicIntegerNumber = 4;
      float _arabicFloatNumber = 4.0f;
      //_arabicIntegerNumber = 4.0f;
      _arabicFloatNumber = 4;
      bool isEqual = 4 == 4.0f;
      string _romanIntegerNumber = "IV";
    }
    [TestMethod]
    public void RomanConversionTest()
    {
      Roman _roman = "IV";
      Assert.AreEqual<int>(4, _roman);
      _roman = "IVXX";
      Assert.AreEqual<int>(14, _roman);
      _roman = 99;
      Assert.AreEqual<int>(99, _roman);
    }
    [TestMethod]
    public void RomanToStringTest()
    {
      Roman _roman = "IV";
      Assert.AreEqual<string>("4", _roman.ToString());
    }
    [TestMethod]
    public void RomanEqualTest()
    {
      Roman _roman1 = "IV";
      Roman _roman2 = "IV";
      Assert.AreEqual(_roman1, _roman2);
    }
    [TestMethod]
    public void MultiplicationOperatorTest()
    {
      //string
      string _romanIntegerString1 = "IV";
      string _romanIntegerString2 = "VI";
      //string _multiplicationStringResult = _romanIntegerString1 * _romanIntegerString2;
      //Roman
      Roman _roman1 = "IV";
      Roman _roman2 = "VI";
      Roman _multiplicationResult = _roman1 * _roman2;
      Assert.AreEqual<int>(24, _multiplicationResult);
    }
  }
}
#pragma warning restore CS0219 // Variable is assigned but its value is never used
