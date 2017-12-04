
namespace TPA.Composition.Plugins.PluginContract
{
  public interface IPlugin
  {
    string Name { get; }
    void PerformAction(IPluginContext context);
  }
}
