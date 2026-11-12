
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2026, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System.Diagnostics;

namespace AdaptiveProgramming.Logging
{
  public class AssemblyTraceEvent
  {
    /// <summary>
    /// Gets the tracer.
    /// </summary>
    /// <value>The tracer.</value>
    public static TraceSource Tracer
    {
      get
      {
        return m_TraceEventInternal.Value;
      }
    }

    private static Lazy<TraceSource> m_TraceEventInternal = new Lazy<TraceSource>(() => new TraceSource("LoggingSourse"));

  }
}
