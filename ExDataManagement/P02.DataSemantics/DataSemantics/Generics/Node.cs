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