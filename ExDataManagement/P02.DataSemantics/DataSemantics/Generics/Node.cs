//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.DataSemantics.Generics
{

  public abstract class Node<TypeParameter>
  {

    public Node<TypeParameter> Next { get; set; }
    //public static Node<TypeParameter> First { get; private set; } = null;
    public TypeParameter Value { get; private set; }
    protected Node(TypeParameter value = default(TypeParameter))
    {
      Value = value;
      //Next = First;
      //First = this;
    }

  }
  
}
