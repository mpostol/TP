//____________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using TPA.ApplicationArchitecture.Data.API;


namespace TPA.ApplicationArchitecture.Data
{
  internal class Linq2SQL : ILinq2SQL
  {

    public override void Connect()
    {
      Console.WriteLine("Text to write");
    }

  }
}
