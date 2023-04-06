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