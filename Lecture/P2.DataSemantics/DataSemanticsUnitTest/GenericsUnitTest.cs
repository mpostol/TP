//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP.DataSemantics.Generics;

namespace TP.DataSemantics
{
  [TestClass]
  public class GenericsUnitTest
  {
    [TestMethod]
    public void AfterCreationValueTestMethod()
    {
      Generics<int> _intInstance = new Generics<int>();
      Assert.AreEqual<int>(default(int), _intInstance.DefaultValue);
    }
    [TestMethod]
    public void AfterCreationReferenceTestMethod()
    {
      Generics<AnyClass> _intInstance = new Generics<AnyClass>();
      Assert.IsNull(_intInstance.DefaultValue);
    }
    [TestMethod]
    public void DictionaryCreatorTestMethod()
    {
      SelfDictionary<EquatableNotImplemented> _dictionSecond = new SelfDictionary<EquatableNotImplemented>();
    }
    [TestMethod]
    [ExpectedException(typeof(NotImplementedException))]
    public void DictionaryNotImplementedExceptionTestMethod()
    {
      SelfDictionary<EquatableNotImplemented> _dictionary = new SelfDictionary<EquatableNotImplemented>();
      _dictionary.AddIfNotPresent(new EquatableNotImplemented());
      EquatableNotImplemented _EquatableNotImplementedInstance = new EquatableNotImplemented();
      _dictionary.AddIfNotPresent(_EquatableNotImplementedInstance);
      Assert.AreEqual<int>(2, _dictionary.Count);
      _dictionary.ContainsKey(_EquatableNotImplementedInstance);
    }

    #region UT instrumentation
    private class AnyClass { }
    private class EquatableNotImplemented : System.IEquatable<EquatableNotImplemented>
    {
      public bool Equals(EquatableNotImplemented other)
      {
        throw new NotImplementedException();
      }
    }
    #endregion

  }
}
