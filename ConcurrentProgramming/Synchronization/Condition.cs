//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Synchronization
{
  /// <summary>
  /// The condition concept offers a way of the synchronization. Each condition is
  /// associated with an important event (condition); hence the appearance of a signal
  /// is meant as appearance of the associated event, which manifests in establishing
  /// the relevant condition. Generally, three kinds of operations on signals are
  /// defined, namely, wait - to suspend process until the associated signal will be
  /// sent, Notify - to awake one of the waiting processes, and IsAwaiting - to check
  /// if any process is waiting for the specified signal.
  /// </summary>
  public sealed class Condition
  {
    private ushort _awaitingCount = 0;

    /// <summary>
    /// Notifies this instance.
    /// use Notify - to awake one of the waiting processes
    /// </summary>
    public void Notify()
    {
      lock (this)
      {
        Monitor.Pulse(this);
      }
    }

    /// <summary>
    /// Notifies all.
    /// use NotifyAll - to awake all of the waiting processes
    /// </summary>
    public void NotifyAll()
    {
      lock (this)
      {
        Monitor.PulseAll(this);
      }
    }

    /// <summary>
    /// Wait until a condition is fulfilled
    /// </summary>
    /// <param name="callingMonitor">The calling monitor.</param>
    /// <remarks>It shall be executed only inside the lock instruction</remarks>
    public void Wait(object callingMonitor)
    {
      lock (this)
      {
        Monitor.Exit(callingMonitor);
        _awaitingCount++;
        Monitor.Wait(this);
        _awaitingCount--;
      }
      Monitor.Enter(callingMonitor);
    }

    /// <summary>
    /// Waits the specified calling monitor until a timeout expires.
    /// </summary>
    /// <param name="callingMonitor">The calling monitor.</param>
    /// <param name="TimeOut">The time out.</param>
    public bool Wait(object callingMonitor, int TimeOut)
    {
      bool res = false;
      lock (this)
      {
        Monitor.Exit(callingMonitor);
        _awaitingCount++;
        res = Monitor.Wait(this, TimeOut);
        _awaitingCount--;
      }
      Monitor.Enter(callingMonitor);
      return res;
    }

    /// <summary>
    /// Releases the lock on a monitor and blocks the current thread until
    /// it receives Notification / Signal or a specified amount of time elapses.
    /// </summary>
    /// <param name="callingMonitor">The monitor which to releases the lock on.</param>
    /// <param name="TimeOut">The number of milliseconds to wait before this method returns. </param>
    /// <returns>true if the lock was reacquired before the specified time elapsed; otherwise, false.
    /// </returns>
    public bool Wait(object callingMonitor, TimeSpan TimeOut)
    {
      bool res = false;
      lock (this)
      {
        Monitor.Exit(callingMonitor);
        _awaitingCount++;
        res = Monitor.Wait(this, TimeOut);
        _awaitingCount--;
      }
      Monitor.Enter(callingMonitor);
      return res;
    }

    /// <summary>
    /// Determines whether this instance is awaiting. checks if any process is waiting for the specified signal
    /// </summary>
    /// <returns>
    /// 	<c>true</c> if this instance is awaiting; otherwise, <c>false</c>.
    /// </returns>
    public bool IsAwaiting()
    {
      return _awaitingCount > 0;
    }
  }
}