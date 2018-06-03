
using System;
using System.Collections.Generic;

namespace TP.Lecture
{
  /// <summary>
  /// Class Generics - an example og generics.
  /// </summary>
  /// <typeparam name="ClassType">The type of the class type.</typeparam>
  public class Generics<ClassType>
  {

    public ClassType DefaultValue { get; private set; } = default(ClassType);
    public Dictionary<int, ClassType> DictionaryProperty { get; private set; } = new Dictionary<int, ClassType>();
    public static ClassType StaticMethod(ClassType parameter)
    {
      return parameter;
    }

    //generic methods
    public bool Equals<MethodType>(ClassType parameter1, ClassType parameter2)
    {
      return parameter1.Equals(parameter2);
    }
    public ClassType GenericMethod<MethodType>(ClassType classTypeParameter)
    {
      Type _type = typeof(MethodType); // MethodType must represent a type.
      //....
      return classTypeParameter;
    }
    public MethodType GenericMethod<MethodType>(MethodType methodTypeParameter)
    {
      return methodTypeParameter;
    }

  }

  public class SelfDictionary<Type> : Dictionary<Type, Type>
    where Type : IEquatable<Type>
  {
    public void AddIfNotPresent(Type entity)
    {
      if (base.ContainsKey(entity))
        return;
      base.Add(entity, entity);
    }
  }
}
