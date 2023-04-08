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

namespace TPD.AsynchronousProgramming.FileSystemWatcherObservable
{
  /// <summary>
  /// Interface ITextReaderProtocolParameters - provides parameters of the DataProvider behavior.
  /// </summary>

  public interface ITextReaderProtocolParameters
  {
    /// <summary>
    /// Gets the column separator - string used to separate columns in the scanned text.
    /// </summary>
    /// <value>The column separator.</value>
    string ColumnSeparator { get; }

    /// <summary>
    /// Gets the delay file scan - it is time to postpone the file content read operation after receiving file modification notification.
    /// It is time needed by the remote application to finalize writing to file and release the file for other processes.
    /// </summary>
    /// <value>The delay file scan.</value>
    double DelayFileScan { get; }

    /// <summary>
    /// Gets the file modification notification timeout.
    /// </summary>
    /// <value><see cref="double"/> representing the file modification notification timeout.</value>
    double FileModificationNotificationTimeout { get; }

    /// <summary>
    /// Gets maximum number of retries this station will try.
    /// </summary>
    /// <value>The maximum number of retries.</value>
    int MaxNumberOfRetries { get; }
  }
}