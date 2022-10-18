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
  /// <summary>
  /// Calling a method is like accessing a field. After the object name (if you're calling an instance method) or the type name (if you're calling a static method), add a period,
  /// the name of the method, and parentheses. Arguments are listed within the parentheses and are separated by commas.
  /// </summary>
  internal abstract class CallingMethodProvider : ICallingMethodProvider
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

    private class CalledMethodProvider
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

      /// <summary>
      /// Writes trace data to the trace listeners in the <see cref="P:System.Diagnostics.TraceSource.Listeners" /> collection using the specified <paramref name="eventType" />,
      /// event identifier <paramref name="id" />, and trace <paramref name="data" />.
      /// </summary>
      /// <param name="eventType">One of the enumeration values that specifies the event type of the trace data.</param>
      /// <param name="id">A numeric identifier for the event.</param>
      /// <param name="data">The trace data.</param>
      public void ConsoleTraceData(TraceEventType eventType, int id, object data)
      {
        Console.WriteLine($"Event type: {eventType}, id: {id}, message: {data}");
      }

      private List<int> callStack = new();
    }

    private CalledMethodProvider TraceSource;
  }
}