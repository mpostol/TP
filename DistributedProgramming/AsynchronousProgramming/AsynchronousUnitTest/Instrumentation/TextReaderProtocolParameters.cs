//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using TPD.ReactiveProgramming.FileSystemWatcherObservable;

namespace TPD.ReactiveProgramming.Instrumentation
{
  /// <summary>
  /// Class TextReaderProtocolParameters - provides editable parameters of the DataProvider behavior
  /// </summary>
  public class TextReaderProtocolParameters : ITextReaderProtocolParameters
  {
    #region ITextReaderProtocolParameters

    /// <summary>
    /// Gets or sets the file modification notification timeout.
    /// </summary>
    /// <value><see cref="double" /> representing the file modification notification timeout.</value>
    public double FileModificationNotificationTimeout { get; } = 60000;

    /// <summary>
    /// Gets the delay file scan - it is time to postpone the file content read operation after receiving file modification notification.
    /// It is time needed by the remote application to finalize writing to file and release the file for other processes.
    /// </summary>
    /// <value>The delay file scan.</value>
    public double DelayFileScan { get; set; } = 1000;

    /// <summary>
    /// Gets the column separator - string used to separate columns in the scanned text.
    /// </summary>
    /// <value>The column separator.</value>
    public string ColumnSeparator { get; set; } = ",";

    /// <summary>
    /// Gets and sets maximum number of retries this station will try.
    /// </summary>
    public int MaxNumberOfRetries { get; set; } = 1;

    #endregion ITextReaderProtocolParameters

    #region Object

    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"ColumnSeparator: \"{ColumnSeparator}\", DelayFileScann: {TimeSpan.FromMilliseconds(DelayFileScan)}, Timeout: {TimeSpan.FromMilliseconds(FileModificationNotificationTimeout)}";
    }

    #endregion Object
  }
}