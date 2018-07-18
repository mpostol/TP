//____________________________________________________________________________
//
//  Copyright (C) Year of Copyright, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections;
using System.Collections.Generic;

namespace TP.DataSemantics.LessonGenerics
{
  public class NodeEnumerable<ValueTypeParameter> : Node<ValueTypeParameter>, IEnumerable<ValueTypeParameter>
  {
    public NodeEnumerable(ValueTypeParameter value) : base(value) {  }

    #region IEnumerable<TypeParameter>
    public IEnumerator<ValueTypeParameter> GetEnumerator()
    {
      Node<ValueTypeParameter> _current = First;
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

  }

}
