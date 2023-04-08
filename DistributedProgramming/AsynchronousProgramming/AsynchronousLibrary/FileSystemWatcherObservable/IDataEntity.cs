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

namespace TPD.AsynchronousProgramming.FileSystemWatcherObservable
{
  /// <summary>
  /// Interface IDataEntity - data holder entity
  /// </summary>
  public interface IDataEntity
  {
    /// <summary>
    /// Gets or sets the tags containing process data this instance captures.
    /// </summary>
    /// <value>The time stamp.</value>
    string[] Tags { get; }

    /// <summary>
    /// Gets or sets the time-stamp.
    /// </summary>
    /// <value>The tags values in the form as they exist in the source file.</value>
    DateTime TimeStamp { get; }
  }
}