//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayersCommunication.Logic.DependencyInjection;

namespace TP.InformationComputation.LayersCommunication.Presentation
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      MethodsCall();
      MethodsCallWrongBehavior();
      ConstructorInjectionExample();
      Console.ReadLine();
    }

    private static void MethodsCallWrongBehavior()
    {
      Console.WriteLine($"Entering {nameof(MethodsCallWrongBehavior)}");
      Logic.ICallingMethodProvider callingMethodProvider = Logic.LogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Charlie();
      callingMethodProvider.Bravo();
      callingMethodProvider.Delta();
      try
      {
        callingMethodProvider.CheckConsistency();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      Console.WriteLine($"Methods call finished");
    }

    private static void MethodsCall()
    {
      Console.WriteLine($"ENtering {nameof(MethodsCall)}");
      Logic.ICallingMethodProvider callingMethodProvider = Logic.LogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Bravo();
      callingMethodProvider.Charlie();
      callingMethodProvider.Delta();
      bool result = callingMethodProvider.CheckConsistency();
      Console.WriteLine($"Finished with result: {result}");
    }

    private static void ConstructorInjectionExample()
    {
      Console.WriteLine($"ENtering {nameof(ConstructorInjectionExample)}");
      ConstructorInjection _ConstructorInjection = new ConstructorInjection(new ConsoleTraceSource());
      _ConstructorInjection.Alpha();
      _ConstructorInjection.Bravo();
      _ConstructorInjection.Charlie();
      _ConstructorInjection.Delta();
      Console.WriteLine($"Methods call finished successfully");
    }
  }
}