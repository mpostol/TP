//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.LayersCommunication.Data
{
  /// <summary>
  /// Data Layer Abstraction is responsible to create the abstract layer interface.
  /// </summary>
  public interface DataAbstraction
  {
    /// <summary>
    /// Creates new object implementing the layer abstract interface <see cref="IData"/>
    /// </summary>
    /// <returns>An object implementing the layer abstract interface <see cref="IData"/>.</returns>
    public static IData CreateData()
    {
      return new DataImplementation();
    }
    private class DataImplementation : IData
    { }
  }
}