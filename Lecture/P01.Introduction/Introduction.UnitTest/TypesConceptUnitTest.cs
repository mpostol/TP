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
  public class TypesConceptUnitTest
  {
    [TestMethod]
    public void TypesCompatibilityTest()
    {
      long ArabicIntegerNumber = 4;
      float ArabicFloatNumber = 4.0f;
      //ArabicIntegerNumber = 4.0f;
      ArabicFloatNumber = 4;
      bool isEqual = 4 == 4.0f;
      string RomanIntegerNumber = "IV";
    }
    [TestMethod]
    public void RomanToIntegerTest()
    {
      int _interger = About.Types.RomanToInteger("IV");
      Assert.AreEqual(4, _interger);
      _interger = About.Types.RomanToInteger("IVXX");
      Assert.AreEqual(14, _interger);
    }
  }
}
#pragma warning restore CS0219 // Variable is assigned but its value is never used
