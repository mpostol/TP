//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TPA.Reflection.Model
{
  internal class TypeMetadata
  {
    private string m_typeName;
    private string m_NamespaceName;
    private TypeMetadata m_BaseType;
    private IEnumerable<TypeMetadata> m_GenericArguments;
    private Tuple<AccessLevel, SealedEnum, AbstractENum> m_Modifiers;
    private TypeKind m_TypeKind;
    private IEnumerable<TypeMetadata> m_ImplementedInterfaces;
    private IEnumerable<TypeMetadata> m_NestedTypes;
    private IEnumerable<PropertyMetadata> m_Properties;
    private TypeMetadata m_DeclaringType;
    private IEnumerable<MethodMetadata> m_Methods;
    private IEnumerable<MethodMetadata> m_Constructors;


    public TypeMetadata(string typeName, string namespaceName)
    {
      m_typeName = typeName;
      m_NamespaceName = namespaceName;
    }
    public TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
    {
      m_GenericArguments = genericArguments;
    }
    private TypeMetadata(Type type)
    {
      m_typeName = type.Name;
      m_DeclaringType = EmitDeclaringType(type.DeclaringType);
      m_Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
      m_Methods = MethodMetadata.EmitMethods(type.GetMethods());
      m_NestedTypes = EmitNestedTypes(type.GetNestedTypes());
      m_ImplementedInterfaces = EmitImplements(type.GetInterfaces());
      m_GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
      m_Modifiers = EmitModifiers(type);
      m_BaseType = EmitExtends(type);
      m_Properties = PropertyMetadata.EmitProperties(type.GetProperties());
      m_TypeKind = GetTypeKind(type);
    }
    internal static TypeMetadata EmitType(Type type)
    {
      return new TypeMetadata(type);
    }
    internal static TypeMetadata EmitReference(Type type)
    {
      if (!type.IsGenericType)
        return new TypeMetadata(type.Name, GetNamespace(type));
      else
        return new TypeMetadata(type.Name, GetNamespace(type), EmitGenericArguments(type.GetGenericArguments()));
    }
    internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> args)
    {
      return from Type arg in args select EmitReference(arg);
    }
    internal static string GetNamespace(Type type)
    {
      string ns = type.Namespace;
      return ns != null ? ns : string.Empty;
    }
    internal static TypeMetadata EmitReturnType(MethodBase method)
    {
      MethodInfo methodInfo = method as MethodInfo;
      if (methodInfo == null)
        return null;
      return EmitReference(methodInfo.ReturnType);
    }
    internal static IEnumerable<ParameterMetadata> EmitParameters(IEnumerable<ParameterInfo> parms)
    {
      return from parm in parms
             select new ParameterMetadata(parm.Name, EmitReference(parm.ParameterType));
    }
    private TypeMetadata EmitDeclaringType(Type declaringType)
    {
      if (declaringType == null)
        return null;
      return EmitReference(declaringType);
    }
    private IEnumerable<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
    {
      return from _type in nestedTypes
             where _type.GetVisible()
             select EmitType(_type);
    }
    private IEnumerable<TypeMetadata> EmitImplements(IEnumerable<Type> interfaces)
    {
      return from currentInterface in interfaces
             select EmitReference(currentInterface);
    }
    private static TypeKind GetTypeKind(Type type)
    {
      return type.IsEnum ? TypeKind.EnumType :
             type.IsValueType ? TypeKind.StructType :
             type.IsInterface ? TypeKind.InterfaceType :
             TypeKind.ClassType;
    }
    static Tuple<AccessLevel, SealedEnum, AbstractENum> EmitModifiers(Type type)
    {
      AccessLevel _access = AccessLevel.IsPrivate;
      if (type.IsPublic)
        _access = AccessLevel.IsPublic;
      else if (type.IsNestedPublic)
        _access = AccessLevel.IsPublic;
      else if (type.IsNestedFamily)
        _access = AccessLevel.IsProtected;
      else if (type.IsNestedFamANDAssem)
        _access = AccessLevel.IsProtectedInternal;
      SealedEnum _sealed = SealedEnum.NotSealed;
      if (type.IsSealed) _sealed = SealedEnum.Sealed;
      AbstractENum _abstract = AbstractENum.NotAbstract;
      if (type.IsAbstract)
        _abstract = AbstractENum.Abstract;
      return new Tuple<AccessLevel, SealedEnum, AbstractENum>(_access, _sealed, _abstract);
    }
    private static TypeMetadata EmitExtends(Type baseType)
    {
      if (baseType == null || baseType == typeof(Object) || baseType == typeof(ValueType) || baseType == typeof(Enum))
        return null;
      return EmitReference(baseType);
    }

  }
}