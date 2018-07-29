//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP.DataStreams.Reflection;

namespace TP.DataStreams
{
  [TestClass]
  public class ReflectionUnitTest
  {

    [TestMethod]
    public void CustomAttributeTest()
    {
      CustomAttribute _attribute = new CustomAttribute() { Description = "Instance description" };
      Assert.IsNotNull(_attribute);
      Assert.AreEqual<string>("Instance description", _attribute.Description);
    }
    [TestMethod]
    public void AttributedClassTest()
    {
      object _unknowObject = AttributedClass.GetObject();
      Type _objectType = _unknowObject.GetType();
      Object[] _attribute = _objectType.GetCustomAttributes(typeof(CustomAttribute), false);
      Assert.AreEqual<int>(1,  _attribute.Length);
      CustomAttribute _expectedAttribute = _attribute[0] as CustomAttribute;
      Assert.IsNotNull(_expectedAttribute);
      Assert.AreEqual<string>("Description of the class", _expectedAttribute.Description);
    }

  }
}
