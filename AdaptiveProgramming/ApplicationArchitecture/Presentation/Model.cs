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

using TPA.ApplicationArchitecture.BusinessLogic;

namespace TPA.ApplicationArchitecture.Presentation
{
  /// <summary>
  /// Class Model is an example of the model layer in the MVVM design pattern.
  /// </summary>
  internal class Model
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class for the production environment bootstrap sequence.
    /// </summary>
    internal Model(BusinessLogicAbstractAPI bussinesLayer = null)
    {
      Data = bussinesLayer ?? BusinessLogicAbstractAPI.CreateLayer();
    }

    private readonly BusinessLogicAbstractAPI Data = default(BusinessLogicAbstractAPI);
  }
}