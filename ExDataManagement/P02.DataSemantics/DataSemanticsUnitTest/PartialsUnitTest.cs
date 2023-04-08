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

namespace TP.DataSemantics.Partials
{
  [TestClass]
  public class PartialsUnitTest
  {
    [TestMethod]
    public void RegularMethodsCallTest()
    {
      PartialClass _newObject = new PartialClass();
      Assert.ThrowsException<System.NotImplementedException>(() => _newObject.MethodPart1());
      Assert.ThrowsException<System.NotImplementedException>(() => _newObject.MethodPart2());
    }

    [TestMethod]
    public void PartialMethodsCallTest()
    {
      PartialClass _newObject = new PartialClass();
      Assert.ThrowsException<System.NotImplementedException>(() => _newObject.PartialMethodCall());
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