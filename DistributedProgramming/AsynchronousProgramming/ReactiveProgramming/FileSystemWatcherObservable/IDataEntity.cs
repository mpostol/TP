//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;

namespace TPD.ReactiveProgramming.FileSystemWatcherObservable
{
  /// <summary>
  /// Interface IDataEntity - data holder entity
  /// </summary>
  internal interface IDataEntity
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