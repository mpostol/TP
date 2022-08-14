//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayersCommunication.Logic;
using TP.InformationComputation.LayersCommunication.Logic.DependencyInjection;

namespace TP.InformationComputation.LayersCommunication.Presentation
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      MethodsCallExample();
      MethodsCallWrongBehaviorExample();
      CallbackExample();
      EventBasedExample();
      ConstructorInjectionExample();
      Console.ReadLine();
    }

    private static void EventBasedExample()
    {
      Console.WriteLine($"ENtering {nameof(EventBasedExample)}");
      ConsoleTraceSource trace = new ConsoleTraceSource();
      IEventBased eventBased = LogicAbstraction.NewEventBased();
      eventBased.TraceDataEvent += trace.TraceData;
      eventBased.Alpha();
      eventBased.Bravo();
      eventBased.Charlie();
      eventBased.Delta();
      Console.WriteLine($"Methods call finished successfully");
    }

    private static void CallbackExample()
    {
      Console.WriteLine($"ENtering {nameof(CallbackExample)}");
      ConsoleTraceSource trace = new ConsoleTraceSource();
      ICallBack _ConstructorInjection = LogicAbstraction.NewICallBack();
      _ConstructorInjection.Alpha(trace.TraceData);
      _ConstructorInjection.Bravo(trace.TraceData);
      _ConstructorInjection.Charlie(trace.TraceData);
      _ConstructorInjection.Delta(trace.TraceData);
      Console.WriteLine($"Methods call finished successfully");
    }

    private static void MethodsCallWrongBehaviorExample()
    {
      Console.WriteLine($"Entering {nameof(MethodsCallWrongBehaviorExample)}");
      ICallingMethodProvider callingMethodProvider = LogicAbstraction.NewCallingMethodProvider();
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

    private static void MethodsCallExample()
    {
      Console.WriteLine($"ENtering {nameof(MethodsCallExample)}");
      Logic.ICallingMethodProvider callingMethodProvider = LogicAbstraction.NewCallingMethodProvider();
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