
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TPA.Reflection.Model
{
  internal class TypeMetadata
  {

    #region constructors
    internal TypeMetadata(Type type)
    {
      m_typeName = type.Name;
      m_DeclaringType = EmitDeclaringType(type.DeclaringType);
      m_Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
      m_Methods = MethodMetadata.EmitMethods(type.GetMethods());
      m_NestedTypes = EmitNestedTypes(type.GetNestedTypes());
      m_ImplementedInterfaces = EmitImplements(type.GetInterfaces());
      m_GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
      m_Modifiers = EmitModifiers(type);
      m_BaseType = EmitExtends(type.BaseType);
      m_Properties = PropertyMetadata.EmitProperties(type.GetProperties());
      m_TypeKind = GetTypeKind(type);
      m_Attributes = type.CustomAttributes;
    }
    #endregion

    #region API
    internal enum TypeKind
    {
      EnumType, StructType, InterfaceType, ClassType
    }
    internal static TypeMetadata EmitReference(Type type)
    {
      if (!type.IsGenericType)
        return new TypeMetadata(type.Name, type.GetNamespace());
      else
        return new TypeMetadata(type.Name, type.GetNamespace(), EmitGenericArguments(type.GetGenericArguments()));
    }
    internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
    {
      return from Type _argument in arguments select EmitReference(_argument);
    }
    #endregion

    #region private
    //vars
    internal string m_typeName;
    internal string m_NamespaceName;
    internal TypeMetadata m_BaseType;
    internal IEnumerable<TypeMetadata> m_GenericArguments;
    internal Tuple<AccessLevel, SealedEnum, AbstractENum> m_Modifiers;
    internal TypeKind m_TypeKind;
    internal IEnumerable<CustomAttributeData> m_Attributes;
    internal IEnumerable<TypeMetadata> m_ImplementedInterfaces;
    internal IEnumerable<TypeMetadata> m_NestedTypes;
    internal IEnumerable<PropertyMetadata> m_Properties;
    internal TypeMetadata m_DeclaringType;
    internal IEnumerable<MethodMetadata> m_Methods;
    internal IEnumerable<MethodMetadata> m_Constructors;
    //constructors
    private TypeMetadata(string typeName, string namespaceName)
    {
      m_typeName = typeName;
      m_NamespaceName = namespaceName;
    }
    private TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
    {
      m_GenericArguments = genericArguments;
    }
    //methods
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
             select new TypeMetadata(_type);
    }
    private IEnumerable<TypeMetadata> EmitImplements(IEnumerable<Type> interfaces)
    {
      return from currentInterface in interfaces
             select EmitReference(currentInterface);
    }
    private static TypeKind GetTypeKind(Type type) //#80 TPA: Reflection - Invalid return value of GetTypeKind() 
    {
      return type.IsEnum ? TypeKind.EnumType :
             type.IsValueType ? TypeKind.StructType :
             type.IsInterface ? TypeKind.InterfaceType :
             TypeKind.ClassType;
    }
    static Tuple<AccessLevel, SealedEnum, AbstractENum> EmitModifiers(Type type)
    {
      //set defaults 
      AccessLevel _access = AccessLevel.IsPrivate;
      AbstractENum _abstract = AbstractENum.NotAbstract;
      SealedEnum _sealed = SealedEnum.NotSealed;
      // check if not default 
      if (type.IsPublic)
        _access = AccessLevel.IsPublic;
      else if (type.IsNestedPublic)
        _access = AccessLevel.IsPublic;
      else if (type.IsNestedFamily)
        _access = AccessLevel.IsProtected;
      else if (type.IsNestedFamANDAssem)
        _access = AccessLevel.IsProtectedInternal;
      if (type.IsSealed)
        _sealed = SealedEnum.Sealed;
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
    #endregion

  }
}