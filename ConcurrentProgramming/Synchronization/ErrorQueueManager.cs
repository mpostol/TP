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
  ///  Title   : Management of concurrent processes
  /// </summary>
  internal class ErrorQueueManager
  {
    #region private

    private static readonly object errorQueueHand = new object();
    private static Lazy<ErrorQueueManager> errorQueue = new Lazy<ErrorQueueManager>(() => new ErrorQueueManager());
    private uint numOfErrors = 0;

    private void Wait()
    {
      lock (this)
      {
        numOfErrors++;
        ErrorQueueChanged(this, new EventArgs());
        lock (errorQueueHand) Monitor.PulseAll(errorQueueHand);
        Monitor.Wait(this);
      }
    }

    private ErrorQueueManager()
    {
      ErrorQueueChanged = (source, args) => { };
    }

    #endregion private

    public static ErrorQueueManager SingletonInstance => errorQueue.Value;

    public event EventHandler<EventArgs> ErrorQueueChanged;

    /// <summary>
    /// Adds to error queue.
    /// </summary>
    public void AddToErrorQueue()
    {
      Wait();
    }

    /// <summary>
    /// Asserts if a condition is held.
    /// </summary>
    /// <param name="assertion">condition of assertion.</param>
    public static void Assert(bool assertion)
    {
      if (!assertion)
        SingletonInstance.AddToErrorQueue();
    }

    /// <summary>
    /// Gets the number of errors.
    /// </summary>
    /// <value>The number of errors.</value>
    public uint NumOfErrors => numOfErrors;
  }
}