using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.DynamicType;
using System.Reflection;

namespace TPA.Reflection.UnitTest.DynamicType
{
    [TestClass]
    public class DemoTypeBuilderUnitTest
    {
        [TestMethod]
        public void TestCreateInstanceWithPublicField()
        {
            object instance = DemoTypeBuilder.CreateInstanceWithPublicField();
            Assert.IsNotNull(instance);

            Type type = instance.GetType();
            Assert.IsNotNull(type);
            Assert.IsTrue(type.Name == "DemoType");

            FieldInfo fieldInfo = type.GetField("m_number");
            Assert.IsNotNull(fieldInfo.GetValue(instance));
            Assert.AreEqual(fieldInfo.GetValue(instance).GetType(), typeof(int));
            Assert.AreEqual(fieldInfo.GetValue(instance), 0);
        }

        [TestMethod]
        public void TestCreateInstanceWithPublicFieldAndDefaultConstructor()
        {
            object instance = DemoTypeBuilder.CreateInstanceWithPublicFieldAndDefaultConstructor();

            Type type = instance.GetType();
            Assert.IsNotNull(type);
            Assert.IsTrue(type.Name == "DemoType2");

            FieldInfo fieldInfo = type.GetField("m_number");
            Assert.IsNotNull(fieldInfo.GetValue(instance));
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
            int res = (int) propertyInfo.GetValue(instance);
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
