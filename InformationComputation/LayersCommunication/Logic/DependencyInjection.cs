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
  internal abstract class DependencyInjection : IPropertyInjection
  {
    #region constructors

    public DependencyInjection(ITraceSource traceEngine)
    {
      TraceSource = traceEngine ?? throw new ArgumentNullException(nameof(traceEngine));
    }

    public DependencyInjection()
    { }

    #endregion constructors

    #region ILogic

    public void Alpha()
    {
      TraceSource?.TraceData(TraceEventType.Verbose, nameof(Alpha).GetHashCode(), "Entering Alpha");
    }

    public void Bravo()
    {
      TraceSource?.TraceData(TraceEventType.Verbose, nameof(Bravo).GetHashCode(), "Entering Bravo");
    }

    public void Charlie()
    {
      TraceSource?.TraceData(TraceEventType.Verbose, nameof(Charlie).GetHashCode(), "Entering Charlie");
    }

    public void Delta()
    {
      TraceSource?.TraceData(TraceEventType.Verbose, nameof(Delta).GetHashCode(), "Entering Delta");
    }

    #endregion ILogic

    #region IPropertyInjection

    public ITraceSource? TraceSource { get; set; }

    #endregion IPropertyInjection
  }
}