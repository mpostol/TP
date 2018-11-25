
using System;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{

  public class InstanceCreationCompletedEventArgs<type> : EventArgs
  {
    public type Result { get; internal set; }
    public InstanceCreationCompletedEventArgs(type instance)
    {
      Result = instance;
    }
  }

}
