using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using TPA.Composition.Plugins.PluginContract;

namespace TPA.Composition.Plugins.Handler
{
    public class PluginSectionHandler : IConfigurationSectionHandler
    {
        public PluginSectionHandler()
        {
        }
        //Handler of .config plugins sections
        //Create and return List of instantialized IPlugin objects
        //Searching all .dll/.exe files in application directory
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<IPlugin> plugins = new List<IPlugin>();
            foreach (XmlNode node in section.ChildNodes)
            {
                try
                {
                    object plugObject =
                              Activator.CreateInstance(Type.GetType(node.Attributes["type"].Value));
                    IPlugin plugin = (IPlugin)plugObject;
                    plugins.Add(plugin);
                }
                catch (Exception) { }
            }
            return plugins;
        }
    }
}
