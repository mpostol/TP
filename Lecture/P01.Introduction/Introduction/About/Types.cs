//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.Generic;

namespace TP.Introduction.About
{
  public static class Types
  {

    public static int RomanToInteger(string roman)
    {
      int number = 0;
      for (int i = 0; i < roman.Length; i++)
      {
        if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
          number -= RomanMap[roman[i]];
        else
          number += RomanMap[roman[i]];
      }
      return number;
    }
    private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };
  }
}

