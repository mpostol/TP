//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using System.ComponentModel;

namespace TP.ConcurrentProgramming.Fundamentals
{
  /// <summary>
  /// Class that allows running method asynchronously
  /// </summary>
  /// <remarks>The RunMethodAsynchronously class is designed to run methods asynchronously using delegates.</remarks>
  public class RunMethodAsynchronously : IDisposable
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="operationToRun">Delegate for the method to be executed asynchronously</param>
    public RunMethodAsynchronously(DoWorkEventHandler operationToRun, RunWorkerCompletedEventHandler completedHandler)
    {
      worker = new();
      worker.DoWork += operationToRun;
      worker.RunWorkerCompleted += completedHandler;
      worker.WorkerSupportsCancellation = false;
      worker.WorkerReportsProgress = false;
    }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Runs the asynchronously method with parameter
    /// </summary>
    public void RunAsync(object? argument)
    {
      if (!worker.IsBusy)
        worker.RunWorkerAsync(argument);
    }

    /// <summary>
    /// Runs the asynchronously method without any additional parameters
    /// </summary>
    public void RunAsync()
    {
      if (!worker.IsBusy)
        worker.RunWorkerAsync();
    }

    #region private

    private readonly BackgroundWorker worker;
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          worker.Dispose();
        }
        disposedValue = true;
      }
    }

    #endregion private
  }
}