
using System;

namespace TP.GraphicalData.Model
{
  /// <summary>
  /// Class User - a class representing user
  /// </summary>
  public class User
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
    public Boolean Active { get; set; }
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
