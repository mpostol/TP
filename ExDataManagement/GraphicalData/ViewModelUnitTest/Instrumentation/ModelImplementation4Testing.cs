//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System.Collections.Generic;
using TP.GraphicalData.Model;

namespace TP.GraphicalData.ViewMode.Test.Instrumentation
{
  /// <summary>
  /// The <seealso cref="ModelSublayerAPI"/> implementation for the testing purpose
  /// </summary>
  internal class ModelImplementation4Testing : ModelSublayerAPI
  {
    public override IEnumerable<IUser> User
    {
      get
      {
        List<IUser> Users = new List<IUser>()
                {
                    new User() { Age = 21, Name = "Jan", Active = true },
                    new User() { Age = 22, Name = "Stefan", Active = false }
                };
        return Users;
      }
    }
  }
}