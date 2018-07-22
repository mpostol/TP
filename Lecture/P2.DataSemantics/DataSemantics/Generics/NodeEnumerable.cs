//____________________________________________________________________________
//
//  Copyright (C) Year of Copyright, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections;
using System.Collections.Generic;

namespace TP.DataSemantics.Generics
{
  public class NodeEnumerable<ValueTypeParameter> : IEnumerable<ValueTypeParameter>
  {
    public NodeEnumerable() { }

    public void Add(Node<ValueTypeParameter> newNode)
    {
      newNode.Next = m_FirstNode;
      m_FirstNode = newNode;
    }
    public Node<ValueTypeParameter> New (ValueTypeParameter value)
    {
      Node<ValueTypeParameter> _ret = new Node<ValueTypeParameter>();
      Add(_ret);
      return _ret;
    }

    #region IEnumerable<TypeParameter>
    public IEnumerator<ValueTypeParameter> GetEnumerator()
    {
      Node<ValueTypeParameter> _current = m_FirstNode;
      while (_current != null)
      {
        ValueTypeParameter _value = _current.Value;
        _current = _current.Next;
        yield return _value;
      }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
    #endregion
    

    private Node<ValueTypeParameter> m_FirstNode = null;

  }

}
