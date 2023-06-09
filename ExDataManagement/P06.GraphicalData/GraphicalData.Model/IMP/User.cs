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

using TP.GraphicalData.Model.API;

namespace TP.GraphicalData.Model.IMP
{
  internal class User : IUser
  {
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    /// <value>The age.</value>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the active.
    /// </summary>
    /// <value>The active.</value>
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