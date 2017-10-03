//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TPA.Reflection.Model
{
  internal class MethodMetadata
  {

    private string name;
    private IEnumerable<TypeMetadata> enumerable1;
    private Tuple<AccessLevel, AbstractENum, StaticEnum, VirtualEnum> m_Modifiers;
    private TypeMetadata typeMetadata;
    private bool m_Extension;
    private IEnumerable<ParameterMetadata> enumerable2;

    public MethodMetadata(MethodBase method, IEnumerable<TypeMetadata> enumerable1, TypeMetadata typeMetadata, IEnumerable<ParameterMetadata> enumerable2)
    {
      this.name = method.Name;
      this.enumerable1 = enumerable1;
      this.typeMetadata = typeMetadata;
      this.enumerable2 = enumerable2;
      m_Modifiers = EmitModifiers(method);
      this.m_Extension = EmitExtension(method);
    }
    internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
    {
      return from MethodBase _currentMethod in methods
             where _currentMethod.GetVisible()
             select new MethodMetadata(_currentMethod,
                          !_currentMethod.IsGenericMethodDefinition ? null : TypeMetadata.EmitGenericArguments(_currentMethod.GetGenericArguments()),
                          TypeMetadata.EmitReturnType(_currentMethod),
                          TypeMetadata.EmitParameters(_currentMethod.GetParameters()));
    }
    private static bool EmitExtension(MethodBase method)
    {
      return method.IsDefined(typeof(ExtensionAttribute), true);
    }
    private static Tuple<AccessLevel, AbstractENum, StaticEnum, VirtualEnum> EmitModifiers(MethodBase method)
    {
      AccessLevel _access = AccessLevel.IsPrivate;
      if (method.IsPublic)
        _access = AccessLevel.IsPublic;
      else if (method.IsFamily)
        _access = AccessLevel.IsProtected;
      else if (method.IsFamilyAndAssembly)
        _access = AccessLevel.IsProtectedInternal;
      AbstractENum _abstract = AbstractENum.NotAbstract;
      if (method.IsAbstract)
        _abstract = AbstractENum.Abstract;
      StaticEnum _static = StaticEnum.NotStatic;
      if (method.IsStatic)
        _static = StaticEnum.Static;
      VirtualEnum _virtual = VirtualEnum.NotVirtual;
      if (method.IsVirtual)
        _virtual = VirtualEnum.Virtual;
      return new Tuple<AccessLevel, AbstractENum, StaticEnum, VirtualEnum>(_access, _abstract, _static, _virtual);
    }

  }
}