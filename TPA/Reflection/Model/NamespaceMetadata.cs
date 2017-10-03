//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TPA.Reflection.Model
{
  internal class NamespaceMetadata
  {
    private IEnumerable<TypeMetadata> m_types;

    private NamespaceMetadata(IEnumerable<TypeMetadata> enumerable) => this.m_types = enumerable;
    internal static NamespaceMetadata EmitNamespace(string ns, IEnumerable<Type> types)
    {
      return new NamespaceMetadata(from type in types orderby type.Name select TypeMetadata.EmitType(type));
    }

  }
}