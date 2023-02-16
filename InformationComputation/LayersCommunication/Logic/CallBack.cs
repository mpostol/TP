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
  internal abstract class CallBack : ICallBack
  {
    public void Alpha(TraceDataDelegate trace)
    {
      trace(TraceEventType.Verbose, nameof(Alpha).GetHashCode(), "Entering Alpha");
    }

    public void Bravo(TraceDataDelegate trace)
    {
      trace(TraceEventType.Verbose, nameof(Bravo).GetHashCode(), "Entering Bravo");
    }

    public void Charlie(TraceDataDelegate trace)
    {
      trace(TraceEventType.Verbose, nameof(Charlie).GetHashCode(), "Entering Charlie");
    }

    public void Delta(TraceDataDelegate trace)
    {
      trace(TraceEventType.Verbose, nameof(Delta).GetHashCode(), "Entering Delta");
    }
  }
}