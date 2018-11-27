//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

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
