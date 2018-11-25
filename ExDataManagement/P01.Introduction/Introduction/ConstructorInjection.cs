//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Diagnostics;

namespace TP.Introduction
{

  public class ConstructorInjection
  {
    public ConstructorInjection(ITraceSource traceEngine)
    {
      m_TraceEngine = traceEngine ?? throw new ArgumentNullException(nameof(traceEngine));
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
