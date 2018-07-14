using System;
using System.Diagnostics;

namespace TP.DependencyInjection
{
  public class ConstructorInjection
  {
    public ConstructorInjection(ITraceSource traceEngine)
    {
      if (traceEngine == null)
        throw new ArgumentNullException(nameof(traceEngine));
      m_TraceEngine = traceEngine;
    }
    public void Alpha()
    {
      m_TraceEngine.TraceData(TraceEventType.Verbose, nameof(Alpha).GetHashCode(), "Entering Alpha");
    }
    public void Bravo()
    {
      m_TraceEngine.TraceData(TraceEventType.Verbose, nameof(Bravo).GetHashCode(), "Entering Bravo");
    }
    public void Charlie()
    {
      m_TraceEngine.TraceData(TraceEventType.Verbose, nameof(Charlie).GetHashCode(), "Entering Charlie");
    }
    public void Delta()
    {
      m_TraceEngine.TraceData(TraceEventType.Verbose, nameof(Delta).GetHashCode(), "Entering Delta");
    }
    private ITraceSource m_TraceEngine;
  }
}
