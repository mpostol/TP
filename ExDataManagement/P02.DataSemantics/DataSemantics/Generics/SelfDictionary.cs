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