
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

    private static Lazy<TraceSource> m_TraceEventInternal = new Lazy<TraceSource>(() => new TraceSource(Assembly.GetExecutingAssembly().GetName().Name) );
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
