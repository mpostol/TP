#nullable disable
//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.GenericClassesMethods
{
  public class Node<TypeParameter>
  {
    public Node<TypeParameter> Next { get; set; }
    public TypeParameter Value { get; private set; }
    public Node(Node<TypeParameter> next, TypeParameter value = default)
    {
      Value = value;
      Next = next;
    }
  }
}
#nullable restore