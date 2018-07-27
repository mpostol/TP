//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace TP.Introduction.About
{
  public static class Types
  {

    public static void TypeCompatibility()
    {
      long ArabicIntegerNumber = 4;
      float ArabicFloatNumber = 4.0f;
      //ArabicIntegerNumber = 4.0f;
      ArabicFloatNumber = 4;
      bool isEqual = 4 == 4.0f;
      string RomanIntegerNumber = "IV";
    }
  }
}

