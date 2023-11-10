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
using System.Runtime.Serialization;

namespace TP.DataStreams.Instrumentation
{
  /// <summary>
  /// Class CustomSerialization - Demonstrates custom serialization approach
  /// </summary>
  /// <seealso cref="System.Runtime.Serialization.ISerializable" />
  [Serializable]
  public class SelfControlSerialization : ISerializable
  {
    #region constructor

    public SelfControlSerialization(double maxIncome, double minIncome)
    {
      MaxIncome = maxIncome;
      MinIncome = minIncome;
    }

    #endregion constructor

    #region API

    /// <summary>
    /// Gets or sets the maximum income.
    /// </summary>
    /// <value>The maximum income.</value>
    public double MaxIncome { get; set; }

    /// <summary>
    /// Gets or sets the minimum income.
    /// </summary>
    /// <value>The minimum income.</value>
    public double MinIncome { get; set; }

    /// <summary>
    /// Gets the average income.
    /// </summary>
    /// <value>The average income.</value>
    public double AverageIncome
    {
      get { return (MaxIncome + MinIncome) / 2; }
    }

    #endregion API

    #region ISerializable

    protected SelfControlSerialization(SerializationInfo info, StreamingContext context)
    {
      // Reset the property value using the GetValue method.
      MaxIncome = info.GetDouble(MaxIncomeKey);
      MinIncome = info.GetDouble(MinIncomeKey);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      // Use the AddValue method to specify serialized values (state of the object).
      info.AddValue(MaxIncomeKey, MaxIncome);
      info.AddValue(MinIncomeKey, MinIncome);
    }

    private const string MaxIncomeKey = "MaxIncomeKey";
    private const string MinIncomeKey = "MinIncomeKey";

    #endregion ISerializable
  }
}