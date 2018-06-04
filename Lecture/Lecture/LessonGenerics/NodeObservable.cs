
using System.Collections;
using System.Collections.Generic;

namespace TP.Lecture.LessonGenerics
{
  public class NodeEnumerable<TypeParameter> : IEnumerable<TypeParameter>
  {
    public NodeEnumerable<TypeParameter> Next { get; private set; }
    public static NodeEnumerable<TypeParameter> First { get; private set; } = null;
    public TypeParameter Value { get; private set; }
    public NodeEnumerable(TypeParameter value)
    {
      Value = value;
      Next = First;
      First = this;
    }

    #region IEnumerable<TypeParameter>
    public IEnumerator<TypeParameter> GetEnumerator()
    {
      NodeEnumerable<TypeParameter> _current = First;
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
    #endregion

  }

}
