//____________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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