//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Diagnostics;

namespace TP.InformationComputation.LayersCommunication.Logic
{
  /// <summary>
  /// Calling a method is like accessing a field. After the object name (if you're calling an instance method) or the type name (if you're calling a static method), add a period,
  /// the name of the method, and parentheses. Arguments are listed within the parentheses and are separated by commas.
  /// </summary>
  internal abstract class CallingMethod : ICallingMethod
  {
    /// <summary>
    /// Creates an instance of the <see cref="CallingMethod"/> to be used to demonstrate how to use a methods call chain for the bidirectional communication purpose.
    /// </summary>
    /// <param name="traceSource">Responsible to provide trace functionality for a methods call chain.</param>
    internal CallingMethod()
    {
      TraceSource = new CallingMethodTraceSource();
    }

    #region ILogic

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

    #endregion ILogic

    #region ICallingMethod

    public bool CheckConsistency()
    {
      return TraceSource.CheckConsistency();
    }

    #endregion ICallingMethod

    #region private

    private class CallingMethodTraceSource
    {
      public void InMemoryTraceData(TraceEventType eventType, int id, object data)
      {
        callStack.Add(id);
      }

      public bool CheckConsistency()
      {
        if (callStack.Count != 4)
          throw new ApplicationException();
        if ("Alpha".GetHashCode() != callStack[0])
          throw new ApplicationException();
        if ("Bravo".GetHashCode() != callStack[1])
          throw new ApplicationException();
        if ("Charlie".GetHashCode() != callStack[2])
          throw new ApplicationException();
        if ("Delta".GetHashCode() != callStack[3])
          throw new ApplicationException();
        return true;
      }

      private List<int> callStack = new();
    }

    #endregion private

    private CallingMethodTraceSource TraceSource;
  }
}