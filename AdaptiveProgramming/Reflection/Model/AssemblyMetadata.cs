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
using System.Linq;
using System.Reflection;

namespace TPA.Reflection.Model
{
  public class AssemblyMetadata
  {
    internal AssemblyMetadata(Assembly assembly)
    {
      m_Name = assembly.ManifestModule.Name;
      m_Namespaces = from Type _type in assembly.GetTypes()
                     group _type by _type.GetNamespace() into _group
                     orderby _group.Key
                     select new NamespaceMetadata(_group.Key, _group);
    }

    internal string m_Name;
    internal IEnumerable<NamespaceMetadata> m_Namespaces;
  }
}