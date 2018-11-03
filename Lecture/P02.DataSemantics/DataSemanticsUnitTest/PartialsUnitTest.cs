//____________________________________________________________________________
//
//  Copyright (C) Year of Copyright, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
