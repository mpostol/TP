//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Globalization;

namespace TPD.ReactiveProgramming.FileSystemWatcherObservable
{
  /// <summary>
  /// Class ReadDataEntity - instance of this class captures selected process data gathered from the buffer.
  /// </summary>
  /// <seealso cref="CAS.Lib.CommonBus.ApplicationLayer.IReadValue" />
  /// TODO Edit XML Comment Template for ReadDataEntity
  internal class ReadDataEntity
  {
    #region private

    private string[] Tags;

    #endregion private

    #region constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadDataEntity"/> class and copies data from the <paramref name="dataBuffer"/> selected by the <paramref name="block"/>.
    /// </summary>
    /// <param name="dataBuffer">The data buffer holding source data.</param>
    /// <param name="block">The data block description to retrieved from the <paramref name="dataBuffer"/>.</param>
    public ReadDataEntity(IDataEntity dataBuffer, int startAddress, short dataType, int length)
    {
      StartAddress = startAddress;
      DataType = dataType;
      Length = length;
      Tags = new string[length];
      for (int i = 0; i < Tags.Length; i++)
        Tags[i] = dataBuffer.Tags[i + startAddress];
    }

    #endregion constructor

    #region IReadValue

    /// <summary>
    /// Gets the data block starting address.
    /// </summary>
    /// <value>The start address.</value>
    public int StartAddress
    {
      get; private set;
    }

    /// <summary>
    /// Gets the length of the data in bytes.
    /// </summary>
    /// <value>The length of data in buffer.</value>
    public int Length
    {
      get; private set;
    }

    /// <summary>
    /// Determines the remote unit address space (resource) the data block belongs to. It could also be used to define
    /// data type if it is determined by address space.
    /// </summary>
    /// <value>The type of the data.</value>
    public short DataType
    {
      get; private set;
    }

    /// <summary>
    /// Checks if the buffer is in the pool or otherwise is alone and used by a user.
    /// Used to the state by the governing pool.
    /// </summary>
    /// <value><c>true</c> if the entity is in pool; otherwise, <c>false</c>.</value>
    public bool InPool
    {
      get => false;
      set { }
    }

    /// <summary>
    /// Check if address belongs to the block
    /// </summary>
    /// <param name="station">station ro be checked</param>
    /// <param name="address">address to be checked</param>
    /// <param name="type">data type</param>
    /// <returns>true if address belongs to the block</returns>
    public bool IsInBlock(ushort address, short type)
    {
      return (type == DataType) && (address >= StartAddress) && (address < (StartAddress + Length));
    }

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
      if (!IsInBlock((ushort)(regAddress + StartAddress), 0))
        throw new ArgumentOutOfRangeException($"The register address is out of the expected range");
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

    #endregion IReadValue
  }
}