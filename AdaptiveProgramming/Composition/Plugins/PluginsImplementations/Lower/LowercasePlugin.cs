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

using TPA.Composition.Plugins.PluginContract;

namespace TPA.Composition.Plugins.PluginsImplementations.Lower
{
  /// <summary>
  /// Represents a plugin (user service) that converts text to lowercase.
  /// </summary>
  public class LowercasePlugin : IPlugin
  {
    public string Name { get => "Lowercase Plugin"; }

    public void PerformAction(IPluginContext context)
    {
      context.Text = context.Text.ToLower();
    }
  }
}