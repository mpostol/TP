//____________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using TPA.ApplicationArchitecture.Data;

namespace TPA.ApplicationArchitecture.BusinessLogic
{
  /// <summary>
  /// Class Model an example exposed by the BusinessLogic layer
  /// </summary>
  public class Model
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class for the production environment bootstrap sequence.
    /// </summary>
    public Model() : this(DataLayerAbstractAPI.CreateLinq2SQL())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class for the testing purpose.
    /// </summary>
    /// <param name="dataLayerAPI">The dataLayerAPI.</param>
    internal Model(DataLayerAbstractAPI dataLayerAPI)
    {
      dataLayerAPI.Connect();
    }
  }
}