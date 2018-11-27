
using TPA.Composition.Plugins.PluginContract;

namespace TPA.Composition.Plugins.PluginsImplementations.Upper
{
  class UppercasePlugin : IPlugin
  {

    public string Name { get => "Uppercase Plugin"; }
    public void PerformAction(IPluginContext context)
    {
      context.Text = context.Text.ToUpper();
    }

  }
}
