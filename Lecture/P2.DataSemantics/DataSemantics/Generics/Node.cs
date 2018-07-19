//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.DataSemantics.Generics
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
