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
using System.Globalization;
using System.IO;

namespace TPD.AsynchronousProgramming.FileSystemWatcherObservable
{
  /// <summary>
  /// Class DataEntity - data holder entity
  /// </summary>
  public class DataEntity : IDataEntity
  {
    #region private

    private DataEntity()
    {
    }

    #endregion private

    #region IDataEntity

    /// <summary>
    /// Gets or sets the time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    public DateTime TimeStamp { get; private set; }

    /// <summary>
    /// Gets or sets the tags containing process data this instance captures.
    /// </summary>
    /// <value>The tags values in the form as they exist in the source file.</value>
    public string[] Tags { get; private set; }

    /// <summary>
    /// Reads the value and convert it to canonical type if possible.
    /// </summary>
    /// <param name="regAddress">The register address.</param>
    /// <param name="canonicalType">Canonical type of the tag.</param>
    /// <returns>System.Object.</returns>
    /// <exception cref="System.NotImplementedException">Is thrown if the value cannot be converted to the requested canonical value.</exception>
    /// <exception cref="System.ArgumentOutOfRangeException">Is thrown if the requested address index is out of range.</exception>
    public type ReadValue<type>(int regAddress)
    {
      object _retValue;
      string _value = Tags[regAddress];
      if (typeof(type) == typeof(string))
        _retValue = _value;
      else if (typeof(type) == typeof(float))
        _retValue = float.Parse(_value, CultureInfo.InvariantCulture);
      else if (typeof(type) == typeof(long))
        _retValue = long.Parse(_value, CultureInfo.InvariantCulture);
      else if (typeof(type) == typeof(int))
        _retValue = int.Parse(_value, CultureInfo.InvariantCulture);
      else if (typeof(type) == typeof(short))
        _retValue = short.Parse(_value, CultureInfo.InvariantCulture);
      else
        throw new NotImplementedException($"The canonical type {typeof(type).ToString()} is not supported");
      return (type)_retValue;
    }

    #endregion IDataEntity

    #region public API

    /// <summary>
    /// Reads the file and the analysis result provide as an instance of <see cref="IDataEntity"/>.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    /// <param name="timeStamp">The time stamp.</param>
    /// <param name="columnSeparator">The column separator.</param>
    /// <returns>IDataEntity.</returns>
    public static IDataEntity ReadFile(string fullPath, DateTime timeStamp, string columnSeparator)
    {
      DataEntity _ret = null;
      string[] _content = File.ReadAllLines(fullPath);
      int _line2Read = int.Parse(_content[0].Trim());
      _ret = new DataEntity() { TimeStamp = timeStamp, Tags = _content[_line2Read].Split(new string[] { columnSeparator }, StringSplitOptions.None) };
      return _ret;
    }

    [System.Diagnostics.Conditional("DEBUG")]
    public static void ReadFile(Action<DataEntity> callback, DateTime timeStamp, string[] values)
    {
      callback(new DataEntity() { TimeStamp = timeStamp, Tags = values });
    }

    #endregion public API
  }
}