//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CodingVType
{
  public static class TypesCompatibility
  {
    public static void ValuesCompatibility()
    {
      long _arabicIntegerNumber = 4;
      float _arabicFloatNumber = 4.0f;
      //_arabicIntegerNumber = 4.0f;
      _arabicFloatNumber = 4;
      bool isEqual = 4 == 4.0f;
    }
  }
}