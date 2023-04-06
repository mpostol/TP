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

using System.Diagnostics;

namespace TP.Introduction
{
  /// <summary>
  /// Class PropertyInjection.
  /// </summary>
  public class PropertyInjection
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyInjection"/> class.
    /// </summary>
    public PropertyInjection() { }

    /// <summary>
    /// Alpha example method.
    /// </summary>
    public void Alpha()
    {
      TraceSource.TraceData(TraceEventType.Verbose, nameof(Alpha).GetHashCode(), "Entering Alpha");
    }

    public void Bravo()
    {
      TraceSource.TraceData(TraceEventType.Verbose, nameof(Bravo).GetHashCode(), "Entering Bravo");
    }

    public void Charlie()
    {
      TraceSource.TraceData(TraceEventType.Verbose, nameof(Charlie).GetHashCode(), "Entering Charlie");
    }

    public void Delta()
    {
      TraceSource.TraceData(TraceEventType.Verbose, nameof(Delta).GetHashCode(), "Entering Delta");
    }

    public ITraceSource TraceSource { get; set; }
  }
}