//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using TP.Introduction;

namespace TP.DependencyInjection.ConsoleApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      ConstructorInjection _ConstructorInjection = new ConstructorInjection(new ConsoleTraceSource());
      _ConstructorInjection.Alpha();
      _ConstructorInjection.Bravo();
      _ConstructorInjection.Charlie();
      _ConstructorInjection.Delta();
      Console.ReadLine();
    }
  }
}
