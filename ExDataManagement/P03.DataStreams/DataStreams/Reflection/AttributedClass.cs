//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;

namespace TP.DataStreams.Reflection
{

  [CustomAttribute("Description of the class")]
  public class AttributedClass
  {
    [Obsolete]
    public static object GetObject()
    {
      return new AttributedClass();
    }
  }
  [AttributeUsage(AttributeTargets.Class)]
  public class CustomAttribute : Attribute
  {
    public CustomAttribute(string attributeDescription)
    {
      Description = attributeDescription;
    }
    public string Description { get; private set; }
  }

}
