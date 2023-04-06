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

using TPA.ApplicationArchitecture.Data;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
  public class TestLinq2SQLFixcture : DataLayerAbstractAPI
  {
    internal int ConnectedCallCount = 0;

    #region ILinq2SQLAPI

    public override void Connect()
    {
      ConnectedCallCount++;
    }

    #endregion ILinq2SQLAPI
  }
}