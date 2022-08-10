//__________________________________________________________________________________________
//
//  Copyright 2021 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayeredArchitecture.Data;

namespace TP.InformationComputation.LayeredArchitecture.Logic.AbstractLayerInterface
{
  internal abstract class LayerFactory
  {
    internal static ILogic CreateLayer(DataLayerAbstractAPI? data = default(DataLayerAbstractAPI))
    {
      return new BusinessLogic(data == null ? DataLayerAbstractAPI.CreateLinq2SQL() : data);
    }

    /// <summary>
    /// Class BusinessLogic - encapsulated implementation of the layer - implements the <see cref="BusinessLogicAbstractAPI" />
    /// </summary>
    /// <seealso cref="TPA.ApplicationArchitecture.BusinessLogic.BusinessLogicAbstractAPI" />
    private class BusinessLogic : ILogic
    {
      public BusinessLogic(DataLayerAbstractAPI dataLayerAPI)
      {
        MyDataLayer = dataLayerAPI;
        MyDataLayer.Connect();
        //handling circular reference at run time.
        graph = new ServiceA() { ServiceB = new ServiceB(new ServiceC()) };
        graph.ServiceB.ServiceC.ServiceA = graph;
      }

      private readonly DataLayerAbstractAPI MyDataLayer;
      private ServiceA? graph = null;

      public IService GraphRoot => throw new NotImplementedException();
    }
  }
}