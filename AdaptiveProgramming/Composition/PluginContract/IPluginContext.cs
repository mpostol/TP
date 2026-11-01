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

namespace AdaptiveProgramming.Composition.Plugins.PluginContract
{
  /// <summary>
  /// Plugin context interface. It is used to pass data between the host application and the plugin.
  /// </summary>
  public interface IPluginContext
  {
    /// <summary>
    /// Gets or sets the text data for the plugin context.
    /// </summary>
    string Text { get; set; }
  }
}