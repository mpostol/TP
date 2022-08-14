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
using TP.InformationComputation.LayersCommunication.Data;

namespace TP.InformationComputation.LayersCommunication.Logic
{
  /// <summary>
  /// Calling a method is like accessing a field. After the object name (if you're calling an instance method) or the type name (if you're calling a static method), add a period,
  /// the name of the method, and parentheses. Arguments are listed within the parentheses and are separated by commas.
  /// </summary>
  internal abstract class CallingMethodProvider: ICallingMethodProvider
  {
    /// <summary>
    /// Creates an instance of the <see cref="CallingMethodProvider"/> to be used to demonstrate how to use a methods call chain for the bidirectional communication purpose.
    /// </summary>
    /// <param name="traceSource">Responsible to provide trace functionality for a methods call chain.</param>
    internal CallingMethodProvider()
    {
      TraceSource = new CalledMethodProvider();
    }

    public void Alpha()
    {
      TraceSource.InMemoryTraceData(TraceEventType.Verbose, nameof(Alpha).GetHashCode(), "Entering Alpha");
    }

    public void Bravo()
    {
      TraceSource.InMemoryTraceData(TraceEventType.Verbose, nameof(Bravo).GetHashCode(), "Entering Bravo");
    }

    public void Charlie()
    {
      TraceSource.InMemoryTraceData(TraceEventType.Verbose, nameof(Charlie).GetHashCode(), "Entering Charlie");
    }

    public void Delta()
    {
      TraceSource.InMemoryTraceData(TraceEventType.Verbose, nameof(Delta).GetHashCode(), "Entering Delta");
    }

    public bool CheckConsistency()
    {
      return TraceSource.CheckConsistency();
    }

    private IData TraceSource;
  }
}