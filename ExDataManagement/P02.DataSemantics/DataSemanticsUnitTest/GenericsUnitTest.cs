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
using TP.DataSemantics.Generics;

namespace TP.DataSemantics
{
  [TestClass]
  public class GenericsUnitTest
  {
    #region Node

    [TestMethod]
    public void ConcreteConstructorMethod()
    {
      DerivedNode _newNode = new DerivedNode();
      Assert.AreEqual<double>(default, _newNode.Value);
    }

    [TestMethod]
    public void GenericConstructorMethod()
    {
      DerivedNode<AnyClass> _newNode = new DerivedNode<AnyClass>();
      Assert.AreEqual<AnyClass>(default, _newNode.Value);
    }

    //instrumentation
    private class DerivedNode<TypeParameter> : Node<TypeParameter> { }

    private class DerivedNode : Node<Double> { }

    private class AnyClass { }

    #endregion Node

    #region NodeEnumerable

    [TestMethod]
    public void NodeEnumerableTest()
    {
      NodeEnumerable<string> _sequence = new NodeEnumerable<string>();
      _sequence.New("Bob Dylan");
      _sequence.New("Joe Bonamassa");
      _sequence.New("Mark Knopfler");
      _sequence.New("Dire Straits");
      _sequence.New("Chris Rea");
      _sequence.New("David Gilmour");
      Assert.IsNotNull(_sequence["David Gilmour"]);
    }

    #endregion NodeEnumerable

    #region SelfDictionary

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

    //instrumentation
    private class EquatableNotImplemented : IEquatable<EquatableNotImplemented>
    {
      public bool Equals(EquatableNotImplemented other)
      {
        throw new NotImplementedException();
      }
    }

    #endregion SelfDictionary
  }
}