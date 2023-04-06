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

namespace TPA.Reflection.Model
{
  internal class NamespaceMetadata
  {
    internal NamespaceMetadata(string name, IEnumerable<Type> types)
    {
      m_NamespaceName = name;
      m_Types = from type in types orderby type.Name select new TypeMetadata(type);
    }

    internal string m_NamespaceName;
    internal IEnumerable<TypeMetadata> m_Types;
  }
}