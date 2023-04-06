//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using TP.Introduction;

namespace TP.DependencyInjection.ConsoleApplication
{
  internal class Program
  {
    private static void Main(string[] args)
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