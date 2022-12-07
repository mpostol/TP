#pragma warning disable CS0219 // Variable is assigned but its value is never used
//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started 
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CustomTypes
{
  [TestClass]
  public class RomanTest
  {

    [TestMethod]
    public void RomanConversionTest()
    {
      Roman roman = "IV";
      Assert.AreEqual<int>(4, roman);
      roman = "IVXX";
      Assert.AreEqual<int>(14, roman);
      roman = 99;
      Assert.AreEqual<int>(99, roman);
    }

    [TestMethod]
    public void RomanToStringTest()
    {
      Roman roman = "IV";
      Assert.AreEqual("4", roman.ToString());
    }

    [TestMethod]
    public void RomanEqualTest()
    {
      Roman roman1 = "IV";
      Roman roman2 = "IV";
      Assert.AreEqual(roman1, roman2);
    }

    [TestMethod]
    public void MultiplicationOperatorTest()
    {
      //string
      string romanIntegerString1 = "IV";
      string romanIntegerString2 = "VI";
      //string _multiplicationStringResult = romanIntegerString1 * romanIntegerString2;
      //Roman
      Roman _roman1 = "IV";
      Roman _roman2 = "VI";
      Roman _multiplicationResult = _roman1 * _roman2;
      Assert.AreEqual<int>(24, _multiplicationResult);
    }
  }
}
#pragma warning restore CS0219 // Variable is assigned but its value is never used
