//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
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
      int arabicIntegerNumber = 4;
      float arabicFloatNumber = 4.0f;
      //arabicIntegerNumber = 4.0f; // it could happen that the calculated value doesn't
                                    //belong to the set of values specified by the float type
      arabicFloatNumber = 4;
    }
  }
}