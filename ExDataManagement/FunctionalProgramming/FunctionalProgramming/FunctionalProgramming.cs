
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

namespace TP.FunctionalProgramming
{
  public static class FunctionalProgramming
  {

    /// <summary>
    /// An example of predicate - stateless processing of the input argument
    /// </summary>
    /// <param name="stringToTest">text to be the subject of testing</param>
    /// <returns>testing result of comparison the <paramref name="stringToTest"/> and 10 and returning <true> if it is greater than 10</returns>
    public static bool StringIsLongPredicate(string stringToTest)
    {
      return stringToTest.Length > 10;
    }

  }
}