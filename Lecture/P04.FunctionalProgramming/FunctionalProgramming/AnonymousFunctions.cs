//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Diagnostics;

namespace TP.FunctionalProgramming
{
  public class AnonymousFunctions
  {

    public static bool StringIsLongPredicate(string stringToTest)
    {
      return stringToTest.Length > 10;
    }

    internal delegate void CallBackTestDelegate( bool testResult);

    [Conditional("DEBUG")]
    internal void ConsistencyCheck(CallBackTestDelegate testResult)
    {
      testResult(true);
    }

  }
}
