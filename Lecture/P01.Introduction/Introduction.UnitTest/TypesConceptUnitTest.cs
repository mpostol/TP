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
      long _arabicIntegerNumber = 4;
      float _arabicFloatNumber = 4.0f;
      //_arabicIntegerNumber = 4.0f;
      _arabicFloatNumber = 4;
      bool isEqual = 4 == 4.0f;
      string _romanIntegerNumber = "IV";
    }
    [TestMethod]
    public void RomanToIntegerTest()
    {
      int _integer = TypesConcept.RomanToInteger("IV");
      Assert.AreEqual(4, _integer);
      _integer = TypesConcept.RomanToInteger("IVXX");
      Assert.AreEqual(14, _integer);
    }
  }
}
#pragma warning restore CS0219 // Variable is assigned but its value is never used
