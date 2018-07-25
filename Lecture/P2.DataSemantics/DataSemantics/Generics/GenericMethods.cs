//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.DataSemantics.Generics
{

  public static class GenericMethods
  {

    public static void Swap<MethodType>(ref MethodType lhs, ref MethodType rhs)
    {
      MethodType temp;
      temp = lhs;
      lhs = rhs;
      rhs = temp;
    }
    public static Tuple<TpeParameter, TpeParameter> SortValues<TpeParameter>(TpeParameter first, TpeParameter second)
      where TpeParameter: IComparable<TpeParameter>
    {
      if (first.CompareTo(second) <= 0)
        return Tuple.Create<TpeParameter, TpeParameter>(first, second);
      else
        return Tuple.Create<TpeParameter, TpeParameter>(second, first);
    }

  }

}
