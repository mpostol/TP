//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayersCommunication.Data;

namespace TP.InformationComputation.LayersCommunication.Logic
{

  /// <summary>
  /// Logic layer abstraction
  /// </summary>
  public interface ILogicAbstraction
  {
    public static ICallingMethod NewCallingMethod()
    {
      return new CallingMethodImplementation();
    }
    public static ICallBack NewICallBack()
    {
      return new CllBackImplementation();
    }
    public static IEventBased NewEventBased()
    {
      return new EventBasedImplementation();
    }
    public static IReactiveProgramming NewReactiveProgramming()
    {
      return new ReactiveProgrammingImplementation();
    }
    public static ILogic NewConstructorInjection(ITraceSource traceEngine)
    {
      return new DependencyInjectionImplementation(traceEngine);
    }
    public static IPropertyInjection NewPropertyInjection()
    {
      return new DependencyInjectionImplementation();
    }

    #region encapsulated definitions
    private class CallingMethodImplementation : CallingMethod
    {
      private IData DataLayer = DataAbstraction.CreateData(); //added to make the three layers of architecture clearly stated
    }
    private class EventBasedImplementation : EventBased{ }
    private class CllBackImplementation : CallBack{ }
    private class ReactiveProgrammingImplementation : ReactiveProgramming{ }
    private class DependencyInjectionImplementation : DependencyInjection
    {
      public DependencyInjectionImplementation(ITraceSource traceEngine) : base(traceEngine) { }
      public DependencyInjectionImplementation() : base() { }
    }
    #endregion encapsulated definitions
  }
}