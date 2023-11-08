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

using System.Collections.Generic;

namespace TP.GraphicalData.Model
{
  //TODO ExDM GraphicalData.UnitTest - implement idependent testing #343
  public abstract class DataLayerAPI
  {
    public IEnumerable<IUser> User { get; }

    public static DataLayerAPI Create()
    {
      return new LayerImplementation.DataLayer();
    }
  }
}