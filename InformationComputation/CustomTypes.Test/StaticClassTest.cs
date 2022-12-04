//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System;

namespace TP.InformationComputation.CustomTypes
{
  [TestClass]
  public class StaticClassTest
  {
    [TestMethod]
    public void StaticClassTestMethod()
    {
      // StaticClass staticClassVariable; //Cannot declare a variable of static type 'StaticClass'

      //StaticClass staticVariable;
      Assert.AreEqual(123456.789, StaticClass.MinIncome);
      Assert.AreEqual(987654.321, StaticClass.MaxIncome);
      StaticClass.StaticClassInitializer(3.0, 1.0);
      Assert.AreEqual(1.0, StaticClass.MinIncome);
      Assert.AreEqual(3.0, StaticClass.MaxIncome);
      Assert.AreEqual(2.0, StaticClass.AverageIncome);
    }
  }
}