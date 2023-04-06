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

namespace TPA.Reflection.DynamicType
{
  public class DynamicExampleClass
  {
    public dynamic Increment(dynamic value)
    {
      //object vs dynamic differences
      object _error = 10;
      //_error += 1; //compiler error
      dynamic _dyn = 0;
      _dyn += 1;
      return value + _dyn;
    }

    public dynamic ExampleMethod(dynamic d)
    {
      dynamic _local = "Local variable";
      int _two = 2;
      if (d is int)
        return _local;
      else
        return _two;
    }
  }
}