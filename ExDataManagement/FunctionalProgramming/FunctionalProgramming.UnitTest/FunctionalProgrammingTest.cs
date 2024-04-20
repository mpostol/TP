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
using static TP.FunctionalProgramming.FunctionalProgramming;

namespace TP.FunctionalProgramming
{
  /// <summary>
  /// Summary description for FunctionalProgrammingTest
  /// </summary>
  [TestClass]
  public class FunctionalProgrammingTest
  {
    [TestMethod]
    public void StringIsLongPredicateTest()
    {
      Assert.IsTrue(StringIsLongPredicate("g5F|z*tC&yKJU$"));
      Assert.IsFalse(StringIsLongPredicate("g5F|z"));
    }

    //public TP.FunctionalProgramming.FunctionalProgramming variable; //Error CS0723  Cannot declare a variable of static type 'FunctionalProgramming'
  }
}