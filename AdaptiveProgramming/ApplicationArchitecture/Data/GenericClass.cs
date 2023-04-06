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

using System.Collections.Generic;

namespace TPA.ApplicationArchitecture.Data
{
  internal class GenericClass<T>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GenericClass{T}"/> class.
    /// </summary>
    /// <param name="genericField">The generic field.</param>
    internal GenericClass(T genericField)
    {
      GenericField = genericField;
    }

    internal List<T> GenericList = new List<T>();
    internal T GenericField;
    internal T GenericProperty { get; set; }

    internal T GenericMethod(T arg)
    {
      return arg;
    }
  }
}