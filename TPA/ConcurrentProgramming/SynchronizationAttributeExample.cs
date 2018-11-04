//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Runtime.Remoting.Contexts;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  [Synchronization]
  public class SynchronizationAttributeExample : ContextBoundObject
  {
    public long LockedNumber;

    public void NoMonitorMethod(object state)
    {
      for (int i = 0; i < 1000000; ++i)
        ++LockedNumber;
    }
  }
}
