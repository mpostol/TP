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

using System;
using System.Collections;
using System.Collections.Generic;

namespace TP.DataSemantics.Generics
{
  public class NodeEnumerable<TypeParameter> : IEnumerable<TypeParameter>
    where TypeParameter : IEquatable<TypeParameter>
  {
    public NodeEnumerable() { }

    public Node<TypeParameter> New(TypeParameter value)
    {
      Node<TypeParameter> _ret = new InternalNode<TypeParameter>(value);
      Add(_ret);
      return _ret;
    }

    public TypeParameter this[TypeParameter selfIndex]
    {
      get
      {
        return m_dictionary[selfIndex];
      }
    }

    #region IEnumerable<TypeParameter>

    public IEnumerator<TypeParameter> GetEnumerator()
    {
      Node<TypeParameter> _current = m_FirstNode;
      while (_current != null)
      {
        TypeParameter _value = _current.Value;
        _current = _current.Next;
        yield return _value;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    #endregion IEnumerable<TypeParameter>

    private class InternalNode<ValueTypeParaTypeParametermeter> : Node<TypeParameter>
    {
      public InternalNode(TypeParameter value) : base(value) { }
    }

    private Node<TypeParameter> m_FirstNode = null;
    private SelfDictionary<TypeParameter> m_dictionary = new SelfDictionary<TypeParameter>();

    private void Add(Node<TypeParameter> newNode)
    {
      newNode.Next = m_FirstNode;
      m_FirstNode = newNode;
      m_dictionary.AddIfNotPresent(newNode.Value);
    }
  }
}