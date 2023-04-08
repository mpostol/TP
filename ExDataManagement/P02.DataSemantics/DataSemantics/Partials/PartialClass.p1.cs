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

namespace TP.DataSemantics.Partials
{
  [SerializableAttribute]
  public partial class PartialClass
  {
    public void MethodPart1()
    {
      throw new System.NotImplementedException();
    }

    public void PartialMethodCall()
    {
      PartialMethod();
    }

    partial void PartialMethod();
  }
}