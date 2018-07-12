namespace TP.Lecture.LessonGenerics
{
  public class Node<ValueTypeParameter>
  {
    public Node<ValueTypeParameter> Next { get; private set; }
    public static Node<ValueTypeParameter> First { get; private set; } = null;
    public ValueTypeParameter Value { get; private set; }
    public Node(ValueTypeParameter value)
    {
      Value = value;
      Next = First;
      First = this;
    }
  }

  
}
