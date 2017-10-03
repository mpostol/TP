//Copyright (C) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TPA.Reflection.Model
{
  internal class AssemblyMetadata
  {
    private string name;
    private IEnumerable<NamespaceMetadata> enumerable;

    private AssemblyMetadata(string name, IEnumerable<NamespaceMetadata> enumerable)
    {
      this.name = name;
      this.enumerable = enumerable;
    }
    internal static AssemblyMetadata EmitAssembly(Assembly assembly)
    {
      return new AssemblyMetadata(assembly.ManifestModule.Name,
                  from type in assembly.GetTypes()
                  where type.GetVisible()
                  group type by TypeMetadata.GetNamespace(type) into g
                  orderby g.Key
                  select NamespaceMetadata.EmitNamespace(g.Key, g));
    }

  }
}