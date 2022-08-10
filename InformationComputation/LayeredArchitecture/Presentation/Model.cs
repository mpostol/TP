//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using TP.InformationComputation.LayeredArchitecture.Logic.AbstractLayerInterface;

namespace TP.InformationComputation.LayeredArchitecture.Presentation
{
  /// <summary>
  /// Class Model is an example of the model layer in the MVVM design pattern.
  /// </summary>
  internal class Model
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class for the production environment bootstrap sequence.
    /// </summary>
    internal Model(ILogic? logicLayer = default(ILogic))
    {
      Data = logicLayer ?? LayerFactory.CreateLayer();
    }

    private readonly ILogic Data;
  }
}