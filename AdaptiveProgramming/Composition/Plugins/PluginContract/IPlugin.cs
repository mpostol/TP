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

namespace TPA.Composition.Plugins.PluginContract
{
  /// <summary>
  /// Service contract for a plugin. A plugin is a component that can be dynamically loaded and executed by the host application. 
  /// The host application can discover and load plugins at runtime, allowing for extensibility and modularity.
  /// </summary>
  public interface IPlugin
  {
    /// <summary>
    /// Name of the plugin. This property is used to identify the plugin and can be used for logging, debugging, or displaying information to the user.
    /// </summary>
    string Name { get; }
    /// <summary>
    /// Performs the action defined by the plugin on the given context.
    /// </summary>
    /// <param name="context"></param>
    void PerformAction(IPluginContext context);
  }
}