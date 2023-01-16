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