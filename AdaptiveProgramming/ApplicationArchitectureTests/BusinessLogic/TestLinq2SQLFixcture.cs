//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

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