namespace TP.Lecture.LessonGenerics
{
  class Node<ClassA>
  {
    public Node<ClassA> Next { get; private set; }
    public static Node<ClassA> First { get; private set; } = null;
    public ClassA Value { get; private set; }
    public Node(ClassA value)
    {
      Value = value;
      Next = First;
      First = this;
    }
  }

  
}
