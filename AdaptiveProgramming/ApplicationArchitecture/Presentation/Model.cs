//____________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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