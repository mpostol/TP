//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CustomTypes
{
  public class Singleton
  {
    public static Singleton SingletonInstance => m_Singleton.Value;

    private Singleton()
    { }

    private static Lazy<Singleton> m_Singleton = new Lazy<Singleton>(() => new Singleton());
  }
}