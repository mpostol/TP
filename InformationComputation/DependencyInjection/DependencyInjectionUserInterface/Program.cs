//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.DependencyInjection
{
  internal class Program1
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

  internal class Program2
  {
    private static void Main(string[] args)
    {
      PropertyInjection propertyInjection = new PropertyInjection();
      propertyInjection.TraceSource = new ConsoleTraceSource();
      propertyInjection.Alpha();
      propertyInjection.Bravo();
      propertyInjection.Charlie();
      propertyInjection.Delta();
      Console.ReadLine();
    }
  }
}