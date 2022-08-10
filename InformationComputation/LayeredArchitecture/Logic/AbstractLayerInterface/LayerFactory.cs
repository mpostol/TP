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
  public abstract class LayerFactory
  {
    public static ILogic CreateLayer(DataLayerAbstract? data = default(DataLayerAbstract))
    {
      return new BusinessLogic(data == null ? DataLayerAbstract.CreateLinq2SQL() : data);
    }

    /// <summary>
    /// Class BusinessLogic - encapsulated implementation of the layer - implements the <see cref="BusinessLogicAbstractAPI" />
    /// </summary>
    /// <seealso cref="TPA.ApplicationArchitecture.BusinessLogic.BusinessLogicAbstractAPI" />
    private class BusinessLogic : ILogic
    {
      #region constructors

      public BusinessLogic(DataLayerAbstract dataLayerAPI)
      {
        MyDataLayer = dataLayerAPI;
        MyDataLayer.Connect();
        //handling circular reference at run time.
        NextService = new ServiceA(new ServiceB(new ServiceC()));
        NextService.Service.Service = NextService;
      }

      #endregion constructors

      #region ILogic

      public IService? NextService { get; private set; }

      #endregion ILogic

      #region private

      private readonly DataLayerAbstract MyDataLayer;

      #endregion private
    }
  }
}