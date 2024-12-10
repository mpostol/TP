//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Fundamentals
{
  public abstract class HoareMonitor
  {
    protected interface ISignal
    {
      /// <summary>
      /// A thread that changes the state of the monitor in a way that might allow a waiting thread to proceed will signal the <see cref="ISignal"/> variable and, 
      /// as a result, awake up one of the waiting threads.
      /// </summary>
      /// <remarks>
      /// The send signal operation needs some scheduling decisions. After sending a signal the thread should immediately wake up the waiting one, if any, 
      /// and give up the monitor to it. It means that the monitor is transferred from a thread issuing a signal to the signaled one. 
      /// The suspended process will afterward regain the processor. This kind of scheduling treats the waiting process as a continuation of the thread that has established 
      /// the awaited condition. The main advantage of the above solution could be revealed when the program validity is proved because the monitor is not released at all, 
      /// and thereby there is no possibility to change the data enclosed by the monitor, and the established condition as well, by another, third process.
      /// </remarks>
      void Send();

      /// <summary>
      /// A thread that cannot proceed because an event is not met will wait on a signal variable.
      /// </summary>
      /// <remarks>
      /// After invoking the wait operation the current process releases all the monitors that it possesses, thus it must leave all relevant data in a consistent state. 
      /// There must be initiated a scheduling mechanism to choose another process to run because the processor is released as well.
      /// </remarks>
      void Wait();

      /// <summary>
      /// Check if any thread is waiting for the specified signal
      /// </summary>
      bool Await();
    }

    protected interface ICondition
    {
      /// <summary>
      /// A thread that changes the state of the monitor in a way that might allow a waiting thread to proceed will signal the condition variable and, 
      /// as a result, awake up one of the waiting threads.
      /// </summary>
      /// <remarks>
      /// This operation is based upon the principle that the signaling thread keeps control of the monitor, and the signaled one changes only its state and becomes ready to run. 
      /// Of course, it cannot be assumed that the announced condition is still fulfilled when the signaled process is resumed, because other processes, 
      /// taking precedence, may have changed it in the meantime. Therefore, the signaled process, just after taking the control, should check again the condition, 
      /// except that it cannot be changed, and, if necessary, wait once more for its occurrence.
      /// </remarks>
      void Send();

      /// <summary>
      /// A thread that cannot proceed because an event is not met will wait on a condition variable.
      /// </summary>
      /// <remarks>
      /// After invoking the wait operation the current process releases all the monitors that it possesses, thus it must leave all relevant data in a consistent state. 
      /// There must be initiated a scheduling mechanism to choose another process to run because the processor is released as well.
      /// </remarks>
      void Wait();

      /// <summary>
      /// Check if any thread is waiting for the specified signal
      /// </summary>
      bool Await();
    }

    /// <summary>
    /// Creates <see cref="ISignal"/> to be instantiated and used inside the monitor. If <see cref="ISignal"/> is not used in the context of the monitor it was created an exception is thrown.
    /// </summary>
    /// <returns>a new instance of <see cref="ISignal"/> attached to this monitor.</returns>
    protected abstract ISignal CreateSignal();

    /// <summary>
    /// Creates <see cref="ICondition"/> to be instantiated and used inside the monitor. If <see cref="ISignal"/> is not used in the context of the monitor it was created an exception is thrown.
    /// </summary>
    /// <returns></returns>
    protected abstract ICondition GetCondition();
  }
}