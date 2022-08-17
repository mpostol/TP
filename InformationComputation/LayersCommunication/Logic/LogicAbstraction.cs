//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Diagnostics;

namespace TP.InformationComputation.LayersCommunication.Logic
{
  public delegate void TraceDataDelegate(TraceEventType eventType, int id, object data);

  public abstract class LogicAbstraction
  {
    public static ICallingMethodProvider NewCallingMethodProvider()
    {
      return new CallingMethodProviderImplementation();
    }

    public static ICallBack NewICallBack()
    {
      return new CllBackImplementation();
    }

    public static IEventBased NewEventBased()
    {
      return new EventBasedImplementation();
    }

    public static ILogic NewConstructorInjection(ITraceSource traceEngine)
    {
      return new ConstructorInjectionImplementation(traceEngine);
    }

    public static IPropertyInjection NewPropertyInjection()
    {
      return new PropertyInjectionImplementation();
    }

    public static IReactiveProgramming NewReactiveProgramming()
    {
      return new ReactiveProgrammingImplementation();
    }

    private class ConstructorInjectionImplementation : ConstructorInjection
    {
      public ConstructorInjectionImplementation(ITraceSource traceEngine) : base(traceEngine)
      { }
    }

    private class PropertyInjectionImplementation : PropertyInjection
    { }

    private class CallingMethodProviderImplementation : CallingMethodProvider
    { }

    private class EventBasedImplementation : EventBased
    { }

    private class CllBackImplementation : CallBack
    { }

    private class ReactiveProgrammingImplementation : ReactiveProgramming
    { }
  }
}