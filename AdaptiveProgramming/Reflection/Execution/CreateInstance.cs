//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.IO;
using System.Reflection;

namespace TPA.Reflection.Execution
{
  //TODO: TPA - create UT for `CreateInstanceFactory`  #47 
  internal static class CreateInstanceFactory
  {

    internal static Tuple<ITraceSource, Assembly> CreateInstance(string assemblyFile)
    {
      FileInfo _pluginFileName = new FileInfo(assemblyFile);
      if (!_pluginFileName.Exists)
        throw new FileNotFoundException(nameof(assemblyFile));
      Assembly _pluginAssembly = Assembly.LoadFrom(_pluginFileName.FullName);
      return new Tuple<ITraceSource, Assembly>(CreateInstance(_pluginAssembly), _pluginAssembly);
    }
    internal static ITraceSource CreateInstance(Assembly pluginAssembly)
    {
      if (pluginAssembly == null)
        throw new NullReferenceException(nameof(pluginAssembly));
      ITraceSource _serverConfiguration = null;
      string _iName = typeof(ITraceSource).ToString();
      foreach (Type pluginType in pluginAssembly.GetExportedTypes())
        //Only look at public types
        if (pluginType.IsPublic && !pluginType.IsAbstract && pluginType.GetInterface(_iName) != null)
        {
          _serverConfiguration = (ITraceSource)Activator.CreateInstance(pluginType);
          break;
        }
      if (_serverConfiguration == null)
        throw new NullReferenceException(nameof(_serverConfiguration));
      return _serverConfiguration;
    }
  }
}
