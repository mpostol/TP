//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.DataStreams.Reflection
{

  [CustomAttribute(Description = "Description of the class")]
  public class AttributedClass
  {
    public static object GetObject()
    {
      return new AttributedClass();
    }
  }
  [AttributeUsage(AttributeTargets.Class)]
  public class CustomAttribute : Attribute
  {
    public string Description { get; set; }
  }

}
