//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CodingVType
{
  [TestClass]
  public class OperationsCompatibilityTest
  {
    [TestMethod]
    public void ValuesCompatibilityTest()
    {
      TypesCompatibility.ValuesCompatibility();
    }

    [TestMethod]
    public void WhyWeNeedTypesIntBehavior()
    {
      int integerValue = 5;
      integerValue = integerValue / 2;
      Assert.AreEqual(2, integerValue);
      float floatValue = 5.0f;
      floatValue = floatValue / 2;
      Assert.AreEqual(2.5f, floatValue);
    }
  }
}