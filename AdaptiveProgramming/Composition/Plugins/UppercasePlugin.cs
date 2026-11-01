//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2026, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using AdaptiveProgramming.Composition.Contracts;

namespace AdaptiveProgramming.Composition.Plugins
{
  /// <summary>
  /// Represents a plugin (user service) that converts text to uppercase.
  /// </summary>
  public class UppercasePlugin : IPluginContract
  {
    public string Name { get => "Uppercase Plugin"; }

    public void PerformAction(IPluginContext context)
    {
      context.Text = context.Text.ToUpper();
    }

    #region Singleton implementation
    /// <summary>
    /// Singleton instance of the UppercasePlugin class. It provides a single point of access to the plugin functionality.
    /// </summary>
    public static IPluginContract PluginInstance { get; } = new UppercasePlugin();
    /// <summary>
    /// Constructor for the LowercasePlugin class. It is private to enforce the singleton pattern and prevent direct instantiation from outside the class.
    /// </summary>
    private UppercasePlugin() { }
    #endregion

  }
}