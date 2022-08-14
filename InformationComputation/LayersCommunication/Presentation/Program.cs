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
      PropertyInjectionExample();
      Console.ReadLine();
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

    private static void MethodsCallWrongBehaviorExample()
    {
      Console.WriteLine($"Entering {nameof(MethodsCallWrongBehaviorExample)}");
      ICallingMethodProvider callingMethodProvider = LogicAbstraction.NewCallingMethodProvider();
      callingMethodProvider.Alpha();
      callingMethodProvider.Charlie();// wrong sequence of calls
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

    private static void EventBasedExample()
    {
      Console.WriteLine($"ENtering {nameof(EventBasedExample)}");
      ConsoleTraceSource consoleTrace = new ConsoleTraceSource();
      IEventBased eventBased = LogicAbstraction.NewEventBased();
      eventBased.TraceDataEvent += consoleTrace.TraceData;
      eventBased.Alpha();
      eventBased.Bravo();
      eventBased.Charlie();
      eventBased.Delta();
      Console.WriteLine($"Methods call finished successfully");
    }

    private static void CallbackExample()
    {
      Console.WriteLine($"ENtering {nameof(CallbackExample)}");
      ConsoleTraceSource consoleTrace = new ConsoleTraceSource();
      ICallBack callBackBased = LogicAbstraction.NewICallBack();
      callBackBased.Alpha(consoleTrace.TraceData);
      callBackBased.Bravo(consoleTrace.TraceData);
      callBackBased.Charlie(consoleTrace.TraceData);
      callBackBased.Delta(consoleTrace.TraceData);
      Console.WriteLine($"Methods call finished successfully");
    }

    private static void ConstructorInjectionExample()
    {
      Console.WriteLine($"ENtering {nameof(ConstructorInjectionExample)}");
      ConstructorInjection constructorInjection = new ConstructorInjection(new ConsoleTraceSource());
      constructorInjection.Alpha();
      constructorInjection.Bravo();
      constructorInjection.Charlie();
      constructorInjection.Delta();
      Console.WriteLine($"Methods call finished successfully");
    }

    private static void PropertyInjectionExample()
    {
      Console.WriteLine($"ENtering {nameof(PropertyInjectionExample)}");
      PropertyInjection propertyInjection = new PropertyInjection();
      propertyInjection.TraceSource = new ConsoleTraceSource();
      propertyInjection.Alpha();
      propertyInjection.Bravo();
      propertyInjection.Charlie();
      propertyInjection.Delta();
      Console.WriteLine($"Methods call finished successfully");
    }
  }
}