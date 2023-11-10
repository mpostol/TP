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