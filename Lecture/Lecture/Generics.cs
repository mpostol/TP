
using System;
using System.Collections.Generic;

namespace TP.Lecture
{
  public class Generics<ClassType>
  {
    public ClassType DefaultValue { get; private set; }
    public Dictionary<int, ClassType> DictionaryPropert { get; private set; }
    public Generics()
    {
      DefaultValue = default(ClassType);
      DictionaryPropert = new Dictionary<int, ClassType>();
    }
    public ClassType GenericMethod<MethodType>(ClassType classTypeParameter)

    {
      Type x = typeof(MethodType); // MethodType must represent a type.
      return classTypeParameter;
    }
    public bool GenericMethod<MethodType>(ClassType parameter1, ClassType parameter2)
    {
      return parameter1.Equals(parameter2);
    }
    public MethodType GenericMethod<MethodType>(MethodType methodTypeParameter)
    {
      return methodTypeParameter;
    }
    public static ClassType StaticMethod (ClassType parameter)
    {
      return parameter;
    }
  }

  public class SelfDictionary<Type>: Dictionary<Type, Type>
    where Type: IEquatable<Type>  //https://msdn.microsoft.com/en-us/library/d5x73970.aspx
  {
    public void AddIfNotPresent(Type entity)
    {
      if (base.ContainsKey(entity))
        return;
      base.Add(entity, entity);
    }
  }
}
