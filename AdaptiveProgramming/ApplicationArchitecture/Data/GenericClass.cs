//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;

namespace TPA.ApplicationArchitecture.Data
{
  public class GenericClass<T>
  {
    public List<T> GenericList;
    public T GenericField;
    public T GenericProperty { get; set; }
    public T GenericMethod(T arg) { return arg; }
  }
}
