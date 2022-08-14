//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayersCommunication.Data;

namespace TP.InformationComputation.LayersCommunication.Logic
{
  public abstract class LogicAbstraction
  {
    public static ICallingMethodProvider NewCallingMethodProvider()
    {
      return new CallingMethodProviderImplementation(DataAbstraction.CreateData());
    }

    private class CallingMethodProviderImplementation : CallingMethodProvider
    {
      public CallingMethodProviderImplementation(IData traceSource) : base(traceSource)
      {
      }
    }
  }
}