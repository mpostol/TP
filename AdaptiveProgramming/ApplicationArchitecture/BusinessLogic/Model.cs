//____________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using TPA.ApplicationArchitecture.Data.API;

namespace TPA.ApplicationArchitecture.BusinessLogic
{
  /// <summary>
  /// Class Model an example exposed by the BusinessLogic layer
  /// </summary>
  public class Model
  {
    internal ILinq2SQL Linq2SQL { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class for the production environment bootstrap sequence.
    /// </summary>
    public Model() : this(ILinq2SQL.CreateLinq2SQL())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Model"/> class for the testing purpose.
    /// </summary>
    /// <param name="linq">The linq.</param>
    internal Model(ILinq2SQL linq)
    {
      Linq2SQL = linq;
    }
  }
}