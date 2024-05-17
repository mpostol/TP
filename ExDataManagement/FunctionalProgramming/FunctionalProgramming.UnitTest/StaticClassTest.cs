//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.FunctionalProgramming
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