//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.Diagnostics;
using System.Reflection;

namespace TPA.Logging.Consumer
{
  /// <summary>
  /// Singleton implementation of the <see cref="TraceSource"/>.
  /// </summary>
  public static class AssemblyTraceEvent
  {
    private static Lazy<TraceSource> m_TraceEventInternal = new Lazy<TraceSource>(() => new TraceSource(Assembly.GetExecutingAssembly().GetName().Name));

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
  }
}