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

using TP.GraphicalData.Model;

namespace TP.GraphicalData.ViewMode.Test.Instrumentation
{
  /// <summary>
  /// <seealso cref="IUser"/> implementation for the testing purpose
  /// </summary>
  internal class User : IUser
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Active { get; set; }

    public override string ToString()
    {
      return Name + " " + Age + " " + Active;
    }
  }
}