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
  public delegate void TraceDataDelegate(TraceEventType eventType, int id, object data);

  public interface ICallBack
  {
    void Alpha(TraceDataDelegate trace);

    void Bravo(TraceDataDelegate trace);

    void Charlie(TraceDataDelegate trace);

    void Delta(TraceDataDelegate trace);
  }
}