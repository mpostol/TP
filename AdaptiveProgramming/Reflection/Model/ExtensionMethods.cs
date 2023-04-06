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
using System.Reflection;

namespace TPA.Reflection.Model
{
  internal static class ExtensionMethods
  {
    internal static bool GetVisible(this Type type)
    {
      return type.IsPublic || type.IsNestedPublic || type.IsNestedFamily || type.IsNestedFamANDAssem;
    }

    internal static bool GetVisible(this MethodBase method)
    {
      return method != null && (method.IsPublic || method.IsFamily || method.IsFamilyAndAssembly);
    }

    internal static string GetNamespace(this Type type)
    {
      string ns = type.Namespace;
      return ns != null ? ns : string.Empty;
    }
  }
}