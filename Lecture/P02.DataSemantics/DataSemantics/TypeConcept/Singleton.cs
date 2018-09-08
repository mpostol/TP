//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.DataSemantics.TypeConcept
{
  public class Singleton
  {
    public static Singleton SingletonInstance => m_Singleton.Value;

    private Singleton() { }
    private static Lazy<Singleton> m_Singleton = new Lazy<Singleton>(() => new Singleton());

  }
}
