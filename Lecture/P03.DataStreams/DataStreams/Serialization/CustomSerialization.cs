//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Runtime.Serialization;

namespace TP.DataStreams.Serialization
{
  /// <summary>
  /// Class CustomSerialization - Demonstrates custom serialization approach
  /// </summary>
  /// <seealso cref="System.Runtime.Serialization.ISerializable" />
  public class CustomSerialization : ISerializable
  {

    public CustomSerialization(double maxIncome, double minIncome)
    {
      MaxIncome = maxIncome;
      MinIncome = minIncome;
    }

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
    #endregion

    #region ISerializable
    public CustomSerialization(SerializationInfo info, StreamingContext context)
    {
      // Reset the property value using the GetValue method.
      MaxIncome = info.GetDouble("MaxIncome");
      MinIncome = info.GetDouble("MinIncome");
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      //// Use the AddValue method to specify serialized values (state of the object).
      info.AddValue("MaxIncome", MaxIncome);
      info.AddValue("MinIncome", MinIncome);
    }
    #endregion

  }

}
