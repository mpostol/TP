//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using TPA.ApplicationArchitecture.Data.API;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
  public class TestLinq2SQLFixcture : ILinq2SQL
  {
    public override void Connect()
    {
      Console.Write("Text to write for UT");
    }
  }
}