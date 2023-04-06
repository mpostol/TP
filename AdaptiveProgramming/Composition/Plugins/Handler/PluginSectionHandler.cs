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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using TPA.Composition.Plugins.PluginContract;

namespace TPA.Composition.Plugins.Handler
{
  public class PluginSectionHandler : IConfigurationSectionHandler
  {
    //Handler of .config plugins sections
    //Create and return List of instantiated IPlugin objects
    //Searching all .dll/.exe files in application directory
    public object Create(object parent, object configContext, XmlNode section)
    {
      List<IPlugin> _plugins = new List<IPlugin>();
      foreach (XmlNode node in section.ChildNodes)
      {
        try
        {
          object _plugObject = Activator.CreateInstance(Type.GetType(node.Attributes["type"].Value));
          IPlugin _plugin = (IPlugin)_plugObject;
          _plugins.Add(_plugin);
        }
        catch (Exception) { }
      }
      return _plugins;
    }
  }
}