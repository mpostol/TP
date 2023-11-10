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

namespace TP.GraphicalData.Model.LayerImplementation
{
  internal class User : IUser
  {
    /// <summary>
    /// Gets or sets the name of a user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the age of a user.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets if a user is active now.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return Name + " " + Age + " " + Active;
    }
  }
}