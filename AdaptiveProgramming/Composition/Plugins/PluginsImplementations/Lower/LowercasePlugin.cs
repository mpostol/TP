
using TPA.Composition.Plugins.PluginContract;

namespace TPA.Composition.Plugins.PluginsImplementations.Lower
{
  class LowercasePlugin : IPlugin
  {

    public string Name { get => "Lowercase Plugin"; }
    public void PerformAction(IPluginContext context)
    {
      context.Text = context.Text.ToLower();
    }

  }
}
