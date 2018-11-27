//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TPA.Reflection.DynamicType;

namespace TPA.Reflection.UnitTest.DynamicType
{
  [TestClass]
  public class DemoTypeBuilderUnitTest
  {
    [TestMethod]
    public void TestCreateInstanceWithPublicField()
    {
      object _instance = DemoTypeBuilder.CreateInstanceWithPublicField();
      Assert.IsNotNull(_instance);
      Type _type = _instance.GetType();
      Assert.IsNotNull(_type);
      Assert.IsTrue(_type.Name == "DemoType");
      FieldInfo _fieldInfo = _type.GetField("m_number");
      Assert.IsNotNull(_fieldInfo);
      Assert.AreEqual(_fieldInfo.GetValue(_instance).GetType(), typeof(int));
      Assert.AreEqual(_fieldInfo.GetValue(_instance), 0);
    }
    [TestMethod]
    public void TestCreateInstanceWithPublicFieldAndDefaultConstructor()
    {
      object instance = DemoTypeBuilder.CreateInstanceWithPublicFieldAndDefaultConstructor();
      Type _type = instance.GetType();
      Assert.IsNotNull(_type);
      Assert.IsTrue(_type.Name == "DemoType2");
      FieldInfo fieldInfo = _type.GetField("m_number");
      Assert.IsNotNull(fieldInfo);
      Assert.AreEqual(fieldInfo.GetValue(instance).GetType(), typeof(int));
      Assert.AreEqual(fieldInfo.GetValue(instance), 7);
    }
    [TestMethod]
    public void TestCreateInstanceWithNonDefaultConstructorAndPublicPropertyAndPrivateField()
    {
      object instance = DemoTypeBuilder.CreateInstanceWithNonDefaultConstructorAndPublicPropertyAndPrivateField();
      Assert.IsNotNull(instance);
      Type type = instance.GetType();
      Assert.IsNotNull(type);
      Assert.IsTrue(type.Name == "DemoType3");
      PropertyInfo propertyInfo = type.GetProperty("MyNumber");
      Assert.IsNotNull(propertyInfo);
      int res = (int)propertyInfo.GetValue(instance);
      Assert.AreEqual(typeof(int), res.GetType());
      Assert.AreEqual(66, res);
      propertyInfo.SetValue(instance, 77);
      res = (int)propertyInfo.GetValue(instance);
      Assert.AreEqual(typeof(int), res.GetType());
      Assert.AreEqual(77, res);
    }
    [TestMethod]
    public void TestCreateInstanceWithPublicMethod()
    {
      object instance = DemoTypeBuilder.CreateInstanceWithPublicMethod();
      Assert.IsNotNull(instance);
      Type type = instance.GetType();
      Assert.IsNotNull(type);
      Assert.IsTrue(type.Name == "DemoType4");
      MethodInfo methodInfo = type.GetMethod("MyMethod");
      Assert.IsNotNull(methodInfo);
      int res = (int)methodInfo.Invoke(instance, new object[] { 4 });
      Assert.AreEqual(typeof(int), res.GetType());
      Assert.AreEqual(5, res);
    }
  }
}
