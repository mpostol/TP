//__________________________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started 
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TPA.ApplicationArchitecture.Data
{
  /// <summary>
  /// Class DataLayerAbstractAPI - an example of the abstract API of the Data layer
  /// </summary>
  public abstract class DataLayerAbstractAPI
  {
    /// <summary>
    /// A place holder to implement the connection functionality.
    /// </summary>
    public abstract void Connect();

    /// <summary>
    /// A factory method to provide new instance of the <see cref="DataLayerAbstractAPI" />.
    /// </summary>
    /// <returns>An instance of DataLayerAbstractAPI.</returns>
    public static DataLayerAbstractAPI CreateLinq2SQL()
    {
      return new Linq2SQL();
    }

    #region Layer implementation

    private class Linq2SQL : DataLayerAbstractAPI
    {
      /// <summary>
      /// A place holder to implement the connection functionality.
      /// </summary>
      public override void Connect()
      {
        throw new System.NotImplementedException();
      }

      #endregion Layer implementation
    }
  }
}