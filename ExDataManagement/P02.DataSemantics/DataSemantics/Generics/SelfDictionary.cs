//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;

namespace TP.DataSemantics.Generics
{
  public class SelfDictionary<Type> : Dictionary<Type, Type>
    where Type : IEquatable<Type>
  {
    public void AddIfNotPresent(Type entity)
    {
      if (base.ContainsKey(entity))
        return;
      base.Add(entity, entity);
    }
  }

}
