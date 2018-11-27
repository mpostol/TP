//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
