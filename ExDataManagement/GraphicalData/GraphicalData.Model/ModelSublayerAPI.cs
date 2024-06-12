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
  /// <summary>
  /// API of the Model sublayer
  /// </summary>
  public abstract class ModelSublayerAPI
  {
    /// <summary>
    /// An example of the sublayer member.
    /// </summary>
    /// <remarks>
    /// Let me stress - to make sure we don't have any dependency on concrete implementation everything must be abstract except types from the library exposed by dot-net
    /// </remarks>
    public abstract IEnumerable<IUser> User { get; }

    /// <summary>
    /// Factoring methods that create an instance of the Model sublayer API
    /// </summary>
    /// <returns>An instance of the <seealso cref="ModelSublayerAPI"/> </returns>
    public static ModelSublayerAPI Create()
    {
      return new LayerImplementation.ModelSublayerImplementation();
    }
  }
}