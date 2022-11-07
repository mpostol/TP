//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayeredArchitecture.Data;

namespace TP.InformationComputation.LayeredArchitecture.Instrumentation
{
  public class DataLayerAbstractFixture : DataLayerAbstract
  {
    internal int ConnectedCallCount = 0;

    #region DataLayerAbstract

    public override void Connect()
    {
      ConnectedCallCount++;
    }

    #endregion DataLayerAbstract
  }
}