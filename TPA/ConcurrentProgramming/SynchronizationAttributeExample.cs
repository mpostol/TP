using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
  [System.Runtime.Remoting.Contexts.Synchronization]
  public class SynchronizationAttributeExample :
    ContextBoundObject
  {
    public long LockedNumber;

    public void NoMonitorMethod(object state)
    {
      for (int i = 0;
        i < 1000000;
        ++i)
      {
        ++LockedNumber;
      }
    }
  }
}
