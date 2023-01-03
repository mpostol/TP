//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP.InformationComputation.PartialDefinitions
{
  [TestClass]
  public class PartialsUnitTest
  {
    [TestMethod]
    public void RegularMethodsCallTest()
    {
      PartialClass _newObject = new PartialClass();
      Assert.ThrowsException<NotImplementedException>(() => _newObject.MethodPart1());
      Assert.ThrowsException<NotImplementedException>(() => _newObject.MethodPart2());
    }

    [TestMethod]
    public void PartialMethodsCallTest()
    {
      PartialClass _newObject = new PartialClass();
      Assert.ThrowsException<NotImplementedException>(() => _newObject.PartialMethodCall());
    }

    [TestMethod]
    public void AttributesTest()
    {
      PartialClass _newObject = new PartialClass();
      Type _partialClassType = _newObject.GetType();
      object[] _attributes = _partialClassType.GetCustomAttributes(false);
      Assert.AreEqual(1, _attributes.Length);
    }
  }
}