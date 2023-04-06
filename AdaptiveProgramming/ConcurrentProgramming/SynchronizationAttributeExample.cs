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
using System.Runtime.Remoting.Contexts;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  [Synchronization]
  public class SynchronizationAttributeExample : ContextBoundObject
  {
    public long LockedNumber;

    public void NoMonitorMethod(object state)
    {
      for (int i = 0; i < 10; ++i)
      {
        long _privateVar = LockedNumber;
        System.Threading.Thread.Sleep(10);
        LockedNumber = ++_privateVar;
      }
    }
  }
}